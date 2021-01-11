using AnchorSystem.Application;
using AnchorSystem.Core.AnchorSystemAuthDb;
using AnchorSystem.Core.AnchorSystemAuthDb.Roles;
using AnchorSystem.Core.AnchorSystemAuthDb.Users;
using AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnchorSystem.Web.Core.Authentication
{
    /// <summary>
    /// 声明工厂
    /// 生成账号的权限
    /// 代理权限固定生成
    /// </summary>
    public class PerClaimsPrincipalFactory : UserClaimsPrincipalFactory<AdminUser, AdminRole>
    {
        private readonly AnchorSystemAuthDbContext _dbContext;

        public PerClaimsPrincipalFactory(
            UserManager<AdminUser> userManager,
            RoleManager<AdminRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            AnchorSystemAuthDbContext dbContext
            ) : base(userManager, roleManager, (optionsAccessor))
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 重写生成声明权限
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public override async Task<ClaimsPrincipal> CreateAsync(AdminUser user)
        {
            var principal = await base.CreateAsync(user);

                if (user.UserType == UserType.Manager)
                {
                    // 管理员权限
                    ((ClaimsIdentity)principal.Identity)?.AddClaims(new[] {
                        new Claim(AgentSystemClaimTypes.PagePermission, "admin"),
                    });
                }
                else
                {
                // 客户权限
                ((ClaimsIdentity)principal.Identity)?.AddClaims(new[] {
                        new Claim(AgentSystemClaimTypes.PagePermission, "client"),
                    });
                }


            // 账号类型
            ((ClaimsIdentity)principal.Identity)?.AddClaims(new[] {
                new Claim(AgentSystemClaimTypes.UserType, (Convert.ToInt32(user.UserType).ToString())),
            });

            return principal;
        }

        /// <summary>
        /// 重写生成声明方法, 原方法使用的Role Name 进行查询,现在改为使用ID查询,
        /// 因为如果多个商户之间有重复Name,会出现角色错乱
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AdminUser user)
        {
            var id = await BaseGenerateClaimsAsync(user);
            if (UserManager.SupportsUserRole)
            {
                var userRoles = _dbContext.UserRoles.Where(m =>
                    m.UserId == user.Id).ToList();  //查询账号原有角色

                //var roles = await UserManager.GetRolesAsync(user);
                foreach (var userRole in userRoles)
                {
                    //
                    if (RoleManager.SupportsRoleClaims)
                    {
                        var role = await RoleManager.FindByIdAsync(userRole.RoleId.ToString());
                        if (role != null)
                        {
                            // 角色名称
                            id.AddClaim(new Claim(Options.ClaimsIdentity.RoleClaimType, role.Name));

                            // 角色声明
                            id.AddClaims(await RoleManager.GetClaimsAsync(role));
                        }
                    }
                }
            }
            return id;
        }

        /// <summary>
        /// 基本声明
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<ClaimsIdentity> BaseGenerateClaimsAsync(AdminUser user)
        {
            var userId = await UserManager.GetUserIdAsync(user);
            var userName = await UserManager.GetUserNameAsync(user);
            var id = new ClaimsIdentity("Identity.Application", // REVIEW: Used to match Application scheme
                Options.ClaimsIdentity.UserNameClaimType,
                Options.ClaimsIdentity.RoleClaimType);
            id.AddClaim(new Claim(Options.ClaimsIdentity.UserIdClaimType, userId));
            id.AddClaim(new Claim(Options.ClaimsIdentity.UserNameClaimType, userName));
            if (UserManager.SupportsUserSecurityStamp)
            {
                id.AddClaim(new Claim(Options.ClaimsIdentity.SecurityStampClaimType,
                    await UserManager.GetSecurityStampAsync(user)));
            }
            if (UserManager.SupportsUserClaim)
            {
                id.AddClaims(await UserManager.GetClaimsAsync(user));
            }
            return id;
        }
    }
}

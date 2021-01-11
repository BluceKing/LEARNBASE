using System;
using AnchorSystem.Core.AnchorSystemAuthDb.Roles;
using AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AnchorSystem.Core.AnchorSystemAuthDb;
using AnchorSystem.Core.AnchorSystemAuthDb.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AnchorSystem.EntityFrameworkCore.Seed.Host
{
    /// <summary>
    /// 初始化角色和用户
    /// </summary>
    public class HostRoleAndUserCreator
    {
        private readonly AnchorSystemAuthDbContext _context;

        public HostRoleAndUserCreator(AnchorSystemAuthDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateHostRoleAndUsers();
        }

        private void CreateHostRoleAndUsers()
        {

            // 管理员账号角色
            var adminRoleForHost = _context.Roles.IgnoreQueryFilters().
                FirstOrDefault(r =>  r.Name == "Admin");
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new AdminRole("Admin", "Admin")
                {
                    IsSystem = true
                }).Entity;
                _context.SaveChanges();
            }

            var adminUserForHost = _context.Users.IgnoreQueryFilters().FirstOrDefault(u =>u.UserName == "admin");
            if (adminUserForHost == null)
            {
                var user = new AdminUser
                {
                    UserName = "admin",
                    NormalizedUserName = "admin".ToUpper(),
                    SecurityStamp = new Guid().ToString(),
                    UserType = UserType.Manager
                };

                user.PasswordHash = new PasswordHasher<AdminUser>(
                    new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(user, "qweqwe123");

                adminUserForHost = _context.Users.Add(user).Entity;
                _context.SaveChanges();

                // Assign Admin role to admin user
                _context.UserRoles.Add(new IdentityUserRole<int>()
                {
                    RoleId = adminRoleForHost.Id,
                    UserId = adminUserForHost.Id
                });
                _context.SaveChanges();
            }
        }
    }
}

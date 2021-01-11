using AnchorSystem.Application;
using AnchorSystem.Core.AnchorSystemAuthDb.Roles;
using AnchorSystem.Core.AnchorSystemAuthDb.Users;
using AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AnchorSystem.Web.Core.Authentication
{
    /// <summary>
    /// 身份授权配置设置
    /// </summary>
    public static class IdentityOptionsRegistrar
    {
        public static void Register(IServiceCollection services)
        {
            // 重置账号验证组件
            services.AddTransient<IUserValidator<AdminUser>, UserAuthUserValidators>();
            services.AddIdentity<AdminUser, AdminRole>()
                .AddEntityFrameworkStores<AnchorSystemAuthDbContext>()
                .AddDefaultTokenProviders()
                .AddClaimsPrincipalFactory<PerClaimsPrincipalFactory>();

            services.Configure<IdentityOptions>(options =>
            {
                // 账号锁定 策略 
                // 账号锁定时间
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                // 密码重试次数
                options.Lockout.MaxFailedAccessAttempts = 5;
                // 默认开启锁定策略
                options.Lockout.AllowedForNewUsers = true;

                // 账号规则
                options.User.RequireUniqueEmail = false; //邮箱非必需

                // 账号允许的符号
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";

                // 密码规则
                options.Password.RequireDigit = true; //是否必须包含数字
                options.Password.RequiredLength = 6; //账号最低长度限制
                options.Password.RequireNonAlphanumeric = false; //是否必须包含符号
                options.Password.RequireUppercase = false; //是否必须包含大写
                options.Password.RequireLowercase = false; //是否必须包含小写

                // 声明自定义
                options.ClaimsIdentity.RoleClaimType = AgentSystemClaimTypes.Role;
                options.ClaimsIdentity.UserNameClaimType = AgentSystemClaimTypes.UserName;
                options.ClaimsIdentity.UserIdClaimType = AgentSystemClaimTypes.UserId;
                options.ClaimsIdentity.SecurityStampClaimType = AgentSystemClaimTypes.SecurityStampClaimType;
            });

        }
    }
}

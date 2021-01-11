using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnchorSystem.Application;
using AnchorSystem.Core.AnchorSystemAuthDb;
using AnchorSystem.Core.AnchorSystemAuthDb.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace AnchorSystem.Web.Core.Config
{
    /// <summary>
    /// 授权策略
    /// </summary>
    public static class AuthorizationPolicyConfigure
    {
        /// <summary>
        /// 授权策略
        /// </summary>
        /// <param name="options"></param>
        public static void AddPolicys(this AuthorizationOptions options)
        {
            var menus = AppMenu.Menus;
            foreach (var menu in menus)
            {
                // 菜单权限
                options.AddPolicy(menu.PerCodeId,
                    policy => policy.RequireClaim(AgentSystemClaimTypes.PagePermission, menu.PerCodeId));

                foreach (var per in menu.Permissions)
                {
                    // 页面和管理权限
                    options.AddPolicy(per.PerCodeId,
                        policy => policy.RequireClaim(AgentSystemClaimTypes.PagePermission, per.PerCodeId));
                }
            }


            // 客户账号
            options.AddPolicy(PerCodeConst.Client, policy => policy.RequireClaim(AgentSystemClaimTypes.UserType,
                Convert.ToInt32(UserType.Client).ToString()));

            // 管理员
            options.AddPolicy(PerCodeConst.Manager,policy => policy.RequireClaim(AgentSystemClaimTypes.UserType,
                Convert.ToInt32(UserType.Manager).ToString()));

            // 超级管理员
            options.AddPolicy(PerCodeConst.Sa, policy => policy.RequireRole("sa"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using AnchorSystem.Application;
using AnchorSystem.Core.AnchorSystemAuthDb;
using AnchorSystem.Core.Exceptions;

namespace AnchorSystem.Web.Core
{
    public static class UserClaimsExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            if (user.Claims.Any(m => m.Type == AgentSystemClaimTypes.UserId))
            {
                return user.Claims.First(m => m.Type == AgentSystemClaimTypes.UserId).Value.ToInt();
            }

            throw new UserFriendlyException("uid error", errorCode: ApiErrorCode.令牌错误);
        }

        public static string GetUserName(this ClaimsPrincipal user)
        {
            if (user.Claims.Any(m => m.Type == AgentSystemClaimTypes.UserName))
            {
                return user.Claims.First(m => m.Type == AgentSystemClaimTypes.UserName).Value;
            }

            throw new UserFriendlyException("name error", errorCode: ApiErrorCode.令牌错误);
        }

        public static string GetUserRole(this ClaimsPrincipal user)
        {
            if (user.Claims.Any(m => m.Type == AgentSystemClaimTypes.Role))
            {
                return user.Claims.First(m => m.Type == AgentSystemClaimTypes.Role).Value;
            }

            throw new NoNullAllowedException("没有role声明！");
        }

        /// <summary>
        /// 读取账号权限列表
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<string> GetUserPerList(this ClaimsPrincipal user)
        {
            if (user.Claims.Any(m => m.Type == AgentSystemClaimTypes.PagePermission))
            {
                return user.Claims.Where(m => m.Type == AgentSystemClaimTypes.PagePermission).Select(m => m.Value).ToList();
            }

            throw new NoNullAllowedException("没有role声明！");
        }

        /// <summary>
        /// 读取当前账号UserType
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static UserType GetUserType(this ClaimsPrincipal user)
        {
            if (user.Claims.Any(m => m.Type == AgentSystemClaimTypes.UserType))
            {
                return (UserType)Convert.ToInt16(
                    user.Claims.First(m => m.Type == AgentSystemClaimTypes.UserType).Value);
            }

            throw new NoNullAllowedException("没有role声明！");
        }

        /// <summary>
        /// 读取SecurityStamp
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetSecurityStamp(this ClaimsPrincipal user)
        {
            if (user.Claims.Any(m => m.Type == AgentSystemClaimTypes.SecurityStampClaimType))
            {
                return user.Claims.First(m => m.Type == AgentSystemClaimTypes.SecurityStampClaimType).Value;
            }

            return string.Empty;
        }

        /// <summary>
        /// 判断账号是否属于管理账号
        /// </summary>
        public static bool IsManager(this ClaimsPrincipal user)
        {
            return user.HasClaim(AgentSystemClaimTypes.UserType, Convert.ToInt32(UserType.Manager).ToString());
        }

        /// <summary>
        /// 判断是否为客户账号
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsMain(this ClaimsPrincipal user)
        {
            //return user.IsInRole("main");
            return user.HasClaim(AgentSystemClaimTypes.UserType, Convert.ToInt32(UserType.Client).ToString());
        }

        /// <summary>
        /// 读取账号是否7天保存
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string GetAutoLogin(this ClaimsPrincipal user)
        {
            if (user.Claims.Any(m => m.Type == AgentSystemClaimTypes.AutoLogin))
            {
                return user.Claims.First(m => m.Type == AgentSystemClaimTypes.AutoLogin).Value;
            }

            return "false";
        }
    }
}

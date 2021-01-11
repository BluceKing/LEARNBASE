using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnchorSystem.Core.AnchorSystemAuthDb.Users
{

    /// <summary>
    /// 后台账号
    /// </summary>
    public class AdminUser : IdentityUser<int>
    {
        /// <summary>
        /// 账号备注
        /// </summary>
        [MaxLength(128)]
        public string Description { get; set; }

        /// <summary>
        /// 是否在线
        /// </summary>
        public bool Online { get; set; }

        /// <summary>
        /// 账号创建时间
        /// </summary>
        public DateTimeOffset CreateTime { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// 账号类型
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// IP白名单
        /// </summary>
        public string WhiteIps { get; set; }

        /// <summary>
        /// 最近登录时间
        /// </summary>
        public DateTimeOffset? LastLoginTime { get; set; }

        /// <summary>
        /// 上次登录Ip
        /// </summary>
        [MaxLength(128)]
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 上次修改密码时间
        /// </summary>
        public DateTimeOffset? LastEditPasswordTime { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// 活跃时间
        /// </summary>
        public DateTimeOffset? ActiveTime { get; set; }
    }
}

using AnchorSystem.Core.AnchorSystemAuthDb.Users;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnchorSystem.Core.AnchorSystemAuthDb.LoginLogs
{
    /// <summary>
    /// 后台账号登陆日志
    /// </summary>
    public class LoginLog
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 登陆时间
        /// </summary>
        public DateTimeOffset LoginTime { get; set; }

        /// <summary>
        /// 登陆Ip信息
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Ip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(1024)]
        public string IpArea { get; set; }

        /// <summary>
        /// 登录域名
        /// </summary>
        [MaxLength(256)]
        public string LoginUrl { get; set; }

        /// <summary>
        /// 登陆日志类型
        /// </summary>
        [Required]
        public EnumLoginLogType LoginLogType { get; set; }

        /// <summary>
        /// 商户
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string TenantId { get; set; }

        /// <summary>
        /// 账号ID
        /// </summary>
        public int UserId { get; set; }
        public AdminUser User { get; set; }

    }
}

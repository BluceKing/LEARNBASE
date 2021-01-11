using System;
using System.ComponentModel.DataAnnotations;

namespace AnchorSystem.Core.AnchorSystemAuthDb
{
    /// <summary>
    /// IP白名单管理
    /// </summary>
    public class IpWhitelist
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string IpAddress { get; set; }

        /// <summary>
        /// 最后的操作人
        /// </summary>
        [MaxLength(256)]
        public string LastOperator { get; set; }

        /// <summary>
        /// 最后的操作时间
        /// </summary>
        public DateTimeOffset LastOperatingTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsUsing { get; set; }
    }
}

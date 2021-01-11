using System;
using System.ComponentModel.DataAnnotations;

namespace AnchorSystem.Core.AnchorSystemAuthDb.OperationRecords
{
    /// <summary>
    /// 操作记录
    /// </summary>
    public class OperationRecord
    {
        public OperationRecord()
        {

        }

        public OperationRecord(string tenantId, string operatorStr, string operatingObject,
            string operatorIp,
            OperatorType operatorType,
            OperatorDetailsType operatorDetailsType)
        {
            Operator = operatorStr;
            OperatingObject = operatingObject;
            OperatingTime = DateTimeOffset.UtcNow;
            OperatorIp = operatorIp;
            OperatorType = operatorType;
            OperatorDetailsType = operatorDetailsType;
        }

        /// <summary>
        /// 自增主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 此次操作的对象
        /// </summary>
        [MaxLength(2048)]
        public string OperatingObject { get; set; }

        /// <summary>
        /// 执行操作的人
        /// </summary>
        [MaxLength(1024)]
        public string Operator { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        [Required]
        public DateTimeOffset OperatingTime { get; set; }

        /// <summary>
        /// MarkDown文本
        /// 可以在此使用MarkDown记录详细操作
        /// </summary>
        public string MarkDownText { get; set; }

        /// <summary>
        /// 操作类别
        /// </summary>
        [Required]
        public OperatorType OperatorType { get; set; }

        /// <summary>
        /// 操作详细类别
        /// </summary>
        [Required]
        public OperatorDetailsType OperatorDetailsType { get; set; }

        /// <summary>
        /// 操作Ip
        /// </summary>
        [MaxLength(128)]
        public string OperatorIp { get; set; }

    }
}

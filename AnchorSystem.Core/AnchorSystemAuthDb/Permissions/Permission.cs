using System.ComponentModel.DataAnnotations;

namespace AnchorSystem.Core.AnchorSystemAuthDb.Permissions
{
    /// <summary>
    /// 页面权限
    /// </summary>
    public class Permission
    {
        public int Id { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 权限代码 唯一
        /// </summary>
        [MaxLength(16)]
        [Required]
        public string PerCodeId { get; set; }

        /// <summary>
        /// 所属菜单ID
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 权限等级
        /// </summary>
        public PerLevel PerLevel { get; set; }

        /// <summary>
        /// 权限限制
        /// </summary>
        public PerLimit PerLimit { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public PerCodeType PerCodeType { get; set; }

        /// <summary>
        /// 所属上级权限
        /// </summary>
        [Required]
        public string ParentId { get; set; }

        /// <summary>
        /// 所属菜单
        /// </summary>
        public Menu Menu { get; set; }
    }
}

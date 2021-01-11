using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnchorSystem.Core.AnchorSystemAuthDb.Permissions
{
    /// <summary>
    /// 最上级菜单
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(16)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 权限代码 唯一
        /// </summary>
        [MaxLength(16)]
        [Required]
        public string PerCodeId { get; set; }

        /// <summary>
        /// 所属权限
        /// </summary>
        public List<Permission> Permissions { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AnchorSystem.Core.AnchorSystemAuthDb.Roles
{
    /// <summary>
    /// 账号角色
    /// </summary>
    public sealed class AdminRole : IdentityRole<int>
    {
        public AdminRole()
        {

        }


        public AdminRole(string name, string displayName)
        {
            Name = name;
            NormalizedName = displayName;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(128)]
        public string Description { get; set; }

        /// <summary>
        /// 是否系统角色 为TRUE 时不能删除
        /// </summary>
        [Required]
        public bool IsSystem { get; set; }

    }
}

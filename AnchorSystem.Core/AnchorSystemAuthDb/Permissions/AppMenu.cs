using System.Collections.Generic;

namespace AnchorSystem.Core.AnchorSystemAuthDb.Permissions
{
    /// <summary>
    /// 固定权限
    /// </summary>
    public class AppMenu
    {
        public static List<Menu> Menus = new List<Menu>()
        {
            new Menu()
            {
                Name = "系统管理",
                PerCodeId = "A1",
                Permissions = new List<Permission>()
                {
                    new Permission()
                    {
                        Name = "白名单管理",
                        PerCodeId = PerCodeConst.SystemManager.白名单管理,
                        PerCodeType = PerCodeType.页面权限,
                        PerLevel = PerLevel.Manager,
                        PerLimit = PerLimit.Manager,
                        ParentId = "A1"
                    },
                    new Permission()
                    {
                        Name = "角色管理",
                        PerCodeId = PerCodeConst.SystemManager.角色管理,
                        PerCodeType = PerCodeType.页面权限,
                        PerLevel = PerLevel.Manager,
                        PerLimit = PerLimit.Manager,
                        ParentId = "A1"
                    },
                    new Permission()
                    {
                        Name = "权限管理",
                        PerCodeId = PerCodeConst.SystemManager.权限管理,
                        PerCodeType = PerCodeType.页面权限,
                        PerLevel = PerLevel.Manager,
                        PerLimit = PerLimit.Manager,
                        ParentId = "A1"
                    },
                    new Permission()
                    {
                        Name = "账号管理",
                        PerCodeId = PerCodeConst.SystemManager.账号管理,
                        PerCodeType = PerCodeType.页面权限,
                        PerLevel = PerLevel.Manager,
                        PerLimit = PerLimit.Manager,
                        ParentId = "A1"
                    },
                    new Permission()
                    {
                        Name = "操作记录",
                        PerCodeId = PerCodeConst.SystemManager.操作记录,
                        PerCodeType = PerCodeType.页面权限,
                        PerLevel = PerLevel.Manager,
                        PerLimit = PerLimit.Manager,
                        ParentId = "A1"
                    },
                    new Permission()
                    {
                        Name = "登录日志",
                        PerCodeId = PerCodeConst.SystemManager.登录日志,
                        PerCodeType = PerCodeType.页面权限,
                        PerLevel = PerLevel.Manager,
                        PerLimit = PerLimit.Manager,
                        ParentId = "A1"
                    }
                }
            },
           
        };
    }
}

namespace AnchorSystem.Core.AnchorSystemAuthDb.OperationRecords
{
    /// <summary>
    /// 操作记录类别枚举
    /// </summary>
    public enum OperatorDetailsType
    {
        新增后台域名管理 = 1001,
        编辑后台域名管理 = 1002,
        删除后台域名管理 = 1003,
        新增ip白名单 = 1101,
        修改ip白名单 = 1102,
        删除ip白名单 = 1103,
        新建角色 = 1201,
        编辑角色 = 1202,
        删除角色 = 1203,
        编辑角色权限 = 1204,
        新增商户 = 1205,
        操作商户余额 = 1206,
        新增公告 = 1207,
        删除公告 = 1208,
        编辑商户基本配置 = 1209,
        编辑商户取款配置 = 1210,
        批量编辑商户取款配置 = 1211,
        编辑商户取款配置白名单 = 1212,
    }
}

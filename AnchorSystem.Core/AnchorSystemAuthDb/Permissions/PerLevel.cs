namespace AnchorSystem.Core.AnchorSystemAuthDb.Permissions
{
    /// <summary>
    /// 权限等级
    /// </summary>
    public enum PerLevel
    {
        /// <summary>
        /// 通用
        /// </summary>
        All = 0,

        /// <summary>
        /// 客户账号
        /// </summary>
        Clients = 1,

        /// <summary>
        /// 管理员账号
        /// </summary>
        Manager = 2,

        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperManager = 3,
    }
}

namespace AnchorSystem.Core.AnchorSystemAuthDb.Permissions
{
    /// <summary>
    /// 限制
    /// </summary>
    public enum PerLimit
    {
        /// <summary>
        /// 没有限制 
        /// </summary>
        All = 0,

        /// <summary>
        /// 管理账号才能拥有的权限
        /// </summary>
        Manager = 1,

        /// <summary>
        /// 客户账号才能拥有的权限
        /// </summary>
        Clients = 2
    }
}

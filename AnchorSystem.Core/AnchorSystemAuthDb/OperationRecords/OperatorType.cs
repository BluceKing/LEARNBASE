namespace AnchorSystem.Core.AnchorSystemAuthDb.OperationRecords
{
    /// <summary>
    /// 操作类别
    /// </summary>
    public enum OperatorType
    {
        /// <summary>
        /// 新增数据
        /// </summary>
        Create = 0,
        /// <summary>
        /// 更新数据
        /// </summary>
        Update = 1,
        /// <summary>
        /// 删除数据
        /// </summary>
        Delete = 2,
        /// <summary>
        /// 系统
        /// </summary>
        System = 3
    }
}

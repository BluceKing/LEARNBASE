namespace AnchorSystem.Core.AnchorSystemAuthDb.Permissions
{
    /// <summary>
    /// 权限列表
    /// </summary>
    public static class PerCodeConst
    {
        /// <summary>
        /// 客户账号
        /// </summary>
        public const string Client = "Client";

        /// <summary>
        /// 管理员
        /// </summary>
        public const string Manager = "Manager";

        /// <summary>
        /// 超管
        /// </summary>
        public const string Sa = "Sa";

        /// <summary>
        /// 系统管理
        /// </summary>
        public static class SystemManager
        {
            public const string 白名单管理 = "A2";
            public const string 角色管理 = "A3";
            public const string 权限管理 = "A4";
            public const string 账号管理 = "A5";
            public const string 操作记录 = "A6";
            public const string 登录日志 = "A7";
        }
    }
}

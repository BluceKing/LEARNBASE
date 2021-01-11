namespace AnchorSystem.Application
{
    public static class AgentSystemClaimTypes
    {
        /// <summary>
        /// 页面权限 如会员管理页面
        /// </summary>
        public const string PagePermission = "per";

        /// <summary>
        /// 管理权限  如会员资料修改
        /// </summary>
        public const string ManagePermission = "mer";

        /// <summary>
        /// 账号主键ID
        /// </summary>
        public const string UserId = "uid";

        /// <summary>
        /// 账号
        /// </summary>
        public const string UserName = "name";

        /// <summary>
        /// 角色
        /// </summary>
        public const string Role = "role";

        /// <summary>
        /// 账号类型
        /// </summary>
        public const string UserType = "utype";

        /// <summary>
        /// SecurityStampClaimType
        /// </summary>
        public const string SecurityStampClaimType = "ssc";

        /// <summary>
        /// 后台验证模式 0无 1操作密码 2双重验证
        /// </summary>
        public const string OperatingMode = "opm";

        /// <summary>
        /// 是否记住账号
        /// </summary>
        public const string AutoLogin = "atol";
    }
}

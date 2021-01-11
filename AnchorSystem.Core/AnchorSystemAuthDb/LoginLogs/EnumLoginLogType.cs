namespace AnchorSystem.Core.AnchorSystemAuthDb.LoginLogs
{
    /// <summary>
    /// 登录日志类型
    /// </summary>
    public enum EnumLoginLogType
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        Success = 0,

        /// <summary>
        /// 账号锁定
        /// </summary>
        UserIsLock = 1,

        /// <summary>
        /// 密码错误
        /// </summary>
        PassWordError = 2,

        /// <summary>
        /// 未授权的IP
        /// </summary>
        UserIpError = 3,
    }
}

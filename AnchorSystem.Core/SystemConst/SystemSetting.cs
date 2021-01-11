namespace AnchorSystem.Core.SystemConst
{
    /// <summary>
    /// 系统设定参数
    /// </summary>
    public class SystemSetting
    {

        /// <summary>
        /// 极验Id
        /// </summary>
        public string VerificationId { get; set; }

        /// <summary>
        /// 极验密钥
        /// </summary>
        public string VerificationKey { get; set; }

        /// <summary>
        /// 上传图片地址
        /// </summary>
        public string UploadApi { get; set; }

        /// <summary>
        /// 上传图片验证参数
        /// </summary>
        public UploadApiBasicAuthConfig UploadApiBasicAuthConfig { get; set; }
    }

    /// <summary>
    /// 上传图片验证参数
    /// </summary>
    public class UploadApiBasicAuthConfig
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
    }
}

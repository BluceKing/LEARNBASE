namespace AnchorSystem.Web.Core.Captcha
{
    /// <summary>
    /// 极验配置
    /// </summary>
    public class CaptchaServiceSetting
    {
        public string VerificationId { get; set; }
        public string VerificationKey { get; set; }

        public int IsEnable { get; set; }
    }
}

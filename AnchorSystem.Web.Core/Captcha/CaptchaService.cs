using GeetestSDK;
using Microsoft.Extensions.Options;

namespace AnchorSystem.Web.Core.Captcha
{
    /// <summary>
    /// 极验验证服务
    /// </summary>
    public class CaptchaService
    {
        private readonly string _verificationId;
        private readonly string _verificationKey;

        public CaptchaService(IOptions<CaptchaServiceSetting> options)
        {
            _verificationId = options.Value.VerificationId;
            _verificationKey = options.Value.VerificationKey;
        }

        /// <summary>
        /// API 1
        /// </summary>
        /// <param name="userId">可忽略</param>
        /// <param name="clientType">web</param>
        /// <param name="ip">用户真实IP 用于极验后台分析统计</param>
        /// <returns></returns>
        public string GetGeetestCaptcha(string userId,
            string clientType,
            string ip)
        {
            var geetest = new GeetestLib(_verificationId, _verificationKey);

            geetest.preProcess(userId, clientType, ip);

            var result = geetest.getResponseStr();
            return result;
        }

        /// <summary>
        /// API 2
        /// </summary>
        /// <param name="challenge">api1 返回参数</param>
        /// <param name="validate">api1 返回参数</param>
        /// <param name="seccode">api1 返回参数</param>
        /// <param name="userId">可忽略</param>
        /// <param name="gtServerStatusCode">1</param>
        /// <returns></returns>
        public bool ValidateGeetest(string challenge,
            string validate,
            string seccode,
            string userId,
            int gtServerStatusCode = 1)
        {
            if ((string.IsNullOrEmpty(challenge) || string.IsNullOrEmpty(validate) || string.IsNullOrEmpty(seccode)))
                return false;

            var geetest = new GeetestLib(_verificationId, _verificationKey);

            //Byte gt_server_status_code = (Byte)Session[GeetestLib.gtServerStatusSessionKey];
            var result = gtServerStatusCode == 1 ?
                geetest.enhencedValidateRequest(challenge, validate, seccode, userId) :
                geetest.failbackValidateRequest(challenge, validate, seccode);
            return result == 1;
        }
    }
}

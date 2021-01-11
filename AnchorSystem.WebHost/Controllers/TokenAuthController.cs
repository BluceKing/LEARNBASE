using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnchorSystem.WebHost.Controllers
{
    /// <summary>
    /// 授权验证
    /// </summary>
    [Route("api/[controller]")]
    public class TokenAuthController
    {
        /// <summary>
        /// 获取授权
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        public  object Auth()
        {
            return "121";
        }
    }
}

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System;

namespace AnchorSystem.Web.Core.Authentication.JwtBearer
{
    /// <summary>
    /// 授权TOKEN  配置
    /// </summary>
    public class TokenAuthConfiguration
    {
        public SymmetricSecurityKey SecurityKey { get; set; }

        ///// <summary>
        ///// Issuer
        ///// </summary>
        //public string Issuer { get; set; }

        /// <summary>
        /// Audience
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 签名 防伪
        /// </summary>
        public SigningCredentials SigningCredentials => new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

        /// <summary>
        /// 访问令牌有效时间
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(1);

        /// <summary>
        /// 刷新令牌默认30分钟有效
        /// </summary>
        public DistributedCacheEntryOptions RefreshTokenExpirationOptions =>
            new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));
    }
}

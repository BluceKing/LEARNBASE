using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using AnchorSystem.Web.Core.Authentication.JwtBearer;
using System;
using System.Text;

namespace AnchorSystem.Web.Core
{
    public static class AuthConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new TokenAuthConfiguration()
            {
                Audience = configuration["Authentication:JwtBearer:Audience"],
                //Issuer = configuration["Authentication:JwtBearer:Issuer"],
                SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"])),
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.Audience = configuration["Authentication:JwtBearer:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Authentication:JwtBearer:SecurityKey"])),

                    // 验证发行API地址
                    ValidateIssuer = false,

                    ValidateAudience = true,
                    ValidAudience = configuration["Authentication:JwtBearer:Audience"],

                    ValidateLifetime = true,

                    ClockSkew = TimeSpan.Zero
                };
                
            });
        }

       
    }
}

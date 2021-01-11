using AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb;
using AnchorSystem.EntityFrameworkCore.Seed;
using AnchorSystem.Web.Core;
using AnchorSystem.Web.Core.Authentication;
using AnchorSystem.Web.Core.Captcha;
using AnchorSystem.Web.Core.Config;
using AnchorSystem.Web.Core.Filters;
using AnchorSystem.Web.Core.Middleware;
using AnchorSystem.WebHost.MapperProfile;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using AnchorSystem.Core.Converter;
using AnchorSystem.Core.SystemConst;

namespace AnchorSystem.WebHost
{
    /// <summary>
    /// 启动
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private MapperConfiguration MapperConfiguration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AnchorSystemMapperProfile());
            });
        }

        /// <summary>
        /// 将服务添加到容器
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // 请求压缩
            services.AddResponseCompression();

            #region 注册组件
            services.AddDbContextPool<AnchorSystemAuthDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(WebConst.AnchorSystemAuthDb)));

            services.AddSingleton(sp => MapperConfiguration.CreateMapper());
            // Identity 注册
            IdentityOptionsRegistrar.Register(services);

            services.Configure<SystemSetting>(Configuration.GetSection("SystemSetting"));

            // 注册极验
            services.Configure<CaptchaServiceSetting>(Configuration.GetSection("SystemSetting"));
            services.AddSingleton<CaptchaService>();

            services.Servicesinjection();

            services.Ip2RegionService();
            #endregion

            //JWT配置 必须在ADDMVC前  identity 后
            AuthConfigurer.Configure(services, Configuration);

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(AnchorSystemAuthorize));  // 账号状态检查
                options.Filters.Add(typeof(BundleApiResultMiddleware)); // Api返回结果包装
                options.Filters.Add(typeof(ExceptionFilter));  // Api异常过滤
                options.Filters.Add(typeof(ValidateAttribute));  // 数据验证
                options.Filters.Add(new AuthorizeFilter());  // 基本授权
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                    ReferenceLoopHandling.Ignore;  //关闭JSON 无限引用
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                options.SerializerSettings.Converters.Add(new BjDateTimeOffsetConverter());
                options.SerializerSettings.Converters.Add(new BjDateTimeOffsetNullConverter());
            });

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentSystem.WebHost", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Please insert JWT with Bearer into field2233",
                    Name = "Authorization",
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>()
                    }
                });
                options.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AnchorSystem.WebHost.xml"));
                options.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AnchorSystem.Application.xml"));
                options.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AnchorSystem.Core.xml"));
            });

            //跨域访问
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder
                            //.AllowAnyOrigin()
                            .AllowCredentials()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed((host) => true);
                    });
            });

            // 验证策略注册
            services.AddAuthorization(options =>
            {
                options.AddPolicys();
            });


            services.AddHealthChecks();

        }

        /// <summary>
        /// 配置HTTP请求管道
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = context =>
                    {
                        context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                        context.Context.Response.Headers.Add("Expires", "-1");
                    }
                });
            }

            app.UseCors("AllowAllHeaders");

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentSystem.WebHost v1"));

            app.UseRouting();
            app.UseAuthentication();  // 权限验证组件
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();  //启用Swagger
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin API V1");
                });
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                Debug.Assert(serviceScope != null, nameof(serviceScope) + " != null");
                var db = serviceScope.ServiceProvider.GetRequiredService<AnchorSystemAuthDbContext>();
                SeedHelper.SeedHostDb(db);
            }
        }

    }
}

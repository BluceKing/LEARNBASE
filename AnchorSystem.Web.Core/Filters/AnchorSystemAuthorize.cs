using AnchorSystem.Core.AnchorSystemAuthDb;
using AnchorSystem.Core.Exceptions;
using AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AnchorSystem.Web.Core.Filters
{
    /// <summary>
    /// 检查账号是否掉线或者被踢线
    /// </summary>
    public class AnchorSystemAuthorize : ActionFilterAttribute
    {
        private readonly AnchorSystemAuthDbContext _dbContext;

        public AnchorSystemAuthorize(AnchorSystemAuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity != null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor
                    && !(controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(inherit: true).Any(a => a.GetType() == typeof(AllowAnonymousAttribute))
                    || controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).Any(a => a.GetType() == typeof(AllowAnonymousAttribute))))
                {
                    var ssc = context.HttpContext.User.GetSecurityStamp();
                    if (!ssc.IsNullOrEmpty())
                    {
                        var user = await _dbContext.Users
                            .FirstOrDefaultAsync(m => m.Id == context.HttpContext.User.GetUserId());

                        if (user != null && !user.SecurityStamp.IsNullOrEmpty() && user.SecurityStamp == ssc)
                        {
                            // 非管理员 且 非活跃标记接口 更新活跃时间
                            if (user.UserType!=UserType.Manager
                                && !controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                                .Any(a => a.GetType().Equals(typeof(NoActiveAttribute))))
                            {
                                // 请求接口更新账号活跃时间
                                // 活跃时间为null 或者 操作间隔大于20分钟时 更改活跃时间 防止操作频繁
                                if (user.ActiveTime == null || user.ActiveTime <= DateTimeOffset.UtcNow.AddMinutes(-20))
                                {
                                    user.ActiveTime = DateTimeOffset.UtcNow;

                                    _dbContext.Users.Attach(user);
                                    _dbContext.Entry(user).Property(x => x.ActiveTime).IsModified = true;

                                    await _dbContext.SaveChangesAsync();
                                }
                            }

                            await next();
                        }
                        else
                        {
                            // 401 未授权
                            context.Result = new UnauthorizedResult();
                        }
                    }
                    else
                    {
                        // 401 未授权
                        context.Result = new UnauthorizedResult();
                    }
                }
                else
                {
                    await next();
                }
            }
            else
            {
                await next();
            }
        }
    }
}

using AnchorSystem.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AnchorSystem.Web.Core.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(
            ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 异常时触发
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var traceId = context.HttpContext.TraceIdentifier;
            if (context.Exception is UserFriendlyException ex)  // 友好异常， 主动throw
            {
                if (ex.IsLog)
                    _logger.LogWarning(context.Exception, context.Exception.Message);
                switch (ex.HttpStatusCode)
                {
                    case 200:  // ok
                        context.Result = new OkObjectResult(new ApiResult<object>(ex)
                        {
                            TraceId = traceId
                        });  //返回一个200状态的  包含错误详情的响应
                        break;
                    default:
                        context.Result = new ObjectResult(new ApiResult<object>(ex)
                        {
                            TraceId = traceId
                        })  //返回非200响应的错误详情
                        {
                            StatusCode = ex.HttpStatusCode,
                        };
                        break;
                }
            }
            else  // 未知异常
            {
                var userFriendlyException =
                    new UserFriendlyException("服务器异常", ApiErrorCode.请求服务器时出错, 500)
                    {
                        Host = context.HttpContext.Request.Host.Value
                    };
                context.Result = new ObjectResult(new ApiResult<object>(userFriendlyException)
                {
                    TraceId = traceId
                })  //返回500响应的错误详情
                {
                    StatusCode = 500
                };

                // TODO: 记录异常堆栈
                _logger.LogError(9999, context.Exception, context.Exception.Message);
            }

            base.OnException(context);
        }

    }
}

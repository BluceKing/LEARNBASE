using AnchorSystem.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AnchorSystem.Web.Core.Filters
{
    /// <summary>
    /// 数据验证属性
    /// </summary>
    public class ValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ApiResult<object>(context.ModelState)
                {
                    Success = false,
                    Host = context.HttpContext.Request.Host.Host,
                    TraceId = context.HttpContext.TraceIdentifier,
                    ErrorCode = ApiErrorCode.提交数据错误,
                    ErrorMessage = ApiErrorCode.提交数据错误.ToString(),
                })
                {
                    StatusCode = 422
                };
            }
        }
    }
}
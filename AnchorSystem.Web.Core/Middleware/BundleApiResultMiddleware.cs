using AnchorSystem.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AnchorSystem.Web.Core.Middleware
{
    public class BundleApiResultMiddleware : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //根据实际需求进行具体实现
            if (context.Result is BadRequestObjectResult)
            {
                // 如果是 BadRequestObjectResult
                // 不包装结果
            }
            else if (context.Result is ObjectResult objectResult)
            {
                context.Result = new ObjectResult(new ApiResult<object>(objectResult.Value));
            }
        }
    }
}

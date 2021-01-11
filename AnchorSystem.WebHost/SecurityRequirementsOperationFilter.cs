using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace AnchorSystem.WebHost
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //var actionAttrs = context.ControllerActionDescriptor.MethodInfo.GetCustomAttributes(true).ToList();
            context.ApiDescription.TryGetMethodInfo(out var methodInfo);
            var actionAttrs = methodInfo.GetCustomAttributes(true).ToList();
            if (actionAttrs.OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            var controllerAttrs = (context.ApiDescription.ActionDescriptor as ControllerActionDescriptor)?.ControllerTypeInfo.GetCustomAttributes(true);
            var actionAbpAuthorizeAttrs = actionAttrs.OfType<AuthorizeAttribute>().ToList();

            if (!actionAbpAuthorizeAttrs.Any() && (controllerAttrs ?? throw new InvalidOperationException()).OfType<AllowAnonymousAttribute>().Any())
            {
                return;
            }
        }

    }
}

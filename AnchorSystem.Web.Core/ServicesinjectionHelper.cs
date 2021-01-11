using AnchorSystem.Application;
using Microsoft.Extensions.DependencyInjection;

namespace AnchorSystem.Web.Core
{
    public static class ServicesinjectionHelper
    {
        public static void Servicesinjection(this IServiceCollection services)
        {
        }

        public static void Ip2RegionService(this IServiceCollection services)
        {
            services.AddSingleton<Ip2RegionService>();
        }
    }
}

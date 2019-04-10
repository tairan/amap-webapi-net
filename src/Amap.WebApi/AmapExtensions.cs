using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Amap.WebApi
{
    public static class AmapExtensions
    {
        public static IServiceCollection AddAmapServices(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddOptions<AmapOptions>();

            services.AddTransient<IGeoService, GeoService>();

            return services;
        }
    }
}

﻿using Microsoft.Extensions.DependencyInjection;

namespace Amap.WebApi
{
    public static class AmapExtensions
    {
        public static IServiceCollection AddAmapServices(this IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddOptions<AmapOptions>();

            services.AddTransient<IGeoService, GeoService>();
            services.AddTransient<IDirectionService, DirectionService>();
            services.AddTransient<IPoiService, PoiService>();
            services.AddTransient<IIpService, IpService>();

            return services;
        }
    }
}

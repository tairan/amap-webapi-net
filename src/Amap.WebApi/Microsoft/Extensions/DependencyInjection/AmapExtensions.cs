using Amap.WebApi;
using Polly;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AmapExtensions
    {
        public static IServiceCollection AddAmap(this IServiceCollection services, Action<AmapOptions> configureOptions)
        {

            services.Configure(configureOptions);

            services.AddHttpClient<IServiceClient>((provider, client) =>
            {
                var item = provider.GetService<AmapOptions>();

                client.BaseAddress = new Uri(item.Host);
            });

            services.AddHttpClient<IDirectionService, DirectionService>()
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));

            services.AddHttpClient<IGeoService, GeoService>()
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));

            services.AddHttpClient<IPoiService, PoiService>()
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));

            services.AddHttpClient<IIpService, IpService>()
            .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));

            return services;
        }
    }
}

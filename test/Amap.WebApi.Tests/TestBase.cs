using System;
using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Amap.WebApi.Tests
{
    public abstract class TestBase
    {
        public readonly int Success_V3 = 1;
        public readonly int Success_V4 = 0;

        public ServiceProvider ServiceProvider =>
            new ServiceCollection()
            .Configure<AmapOptions>(options => options.Key = Key)
            .AddHttpClient()
            .AddLogging()
            .AddAmapServices()
            .BuildServiceProvider();

        public IConfiguration Configuration =>
            new ConfigurationBuilder()
               .AddUserSecrets(Assembly.GetExecutingAssembly())
               .Build();

        public string Key =>
            Configuration.GetSection("amap:key").Value;

        public ILoggerFactory LoggerFactory =>
            ServiceProvider.GetRequiredService<ILoggerFactory>();

        public IHttpClientFactory HttpClientFactory =>
            ServiceProvider.GetRequiredService<IHttpClientFactory>();

        public IOptionsSnapshot<AmapOptions> AmapOptions =>
            ServiceProvider.GetRequiredService<IOptionsSnapshot<AmapOptions>>();
    }
}

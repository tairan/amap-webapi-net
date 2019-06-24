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
            .AddAmap(options =>
            {
                options.Key = Key;
            })
            .BuildServiceProvider();

        public IConfiguration Configuration =>
            new ConfigurationBuilder()
               .AddUserSecrets(Assembly.GetExecutingAssembly())
               .Build();

        public string Key =>
            Configuration.GetSection("amap:key").Value;

        public IOptionsSnapshot<AmapOptions> AmapOptions =>
            ServiceProvider.GetRequiredService<IOptionsSnapshot<AmapOptions>>();
    }
}

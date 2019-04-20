using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amap.WebApi.Shared;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Amap.WebApi.Tests
{
    public class IpTest : TestBase
    {
        private readonly IIpService _ipService;

        public IpTest()
        {
            _ipService = ServiceProvider.GetRequiredService<IIpService>();
        }

        [Theory]
        [InlineData("114.247.50.2")]
        public async Task GetIpAsync_Success(string ip)
        {
            var result = await _ipService.GetIpAsync(ip);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }
    }
}

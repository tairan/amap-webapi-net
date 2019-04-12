using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Amap.WebApi.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NSubstitute;
using Xunit;

namespace Amap.WebApi.Tests
{
    public class GeoTest : TestBase
    {
        private readonly IGeoService _geoService;

        public GeoTest()
        {
            _geoService = ServiceProvider.GetRequiredService<IGeoService>();
        }

        [Theory]
        [InlineData("方恒国际中心A座", "北京", false)]
        public async Task GetGeoAsync_Success(string address, string city, bool batch)
        {
            var result = await _geoService.GetGeoAsync(address, city, batch);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }

        [Theory]
        [InlineData("116.481488,39.990464", "商务写字楼", false, 1000, "all", 0, 0)]
        public async Task GetRegeoAsync_Success(string location, string poitype, bool batch, int radius, string extensions, int roadlevel, int homeorcorp)
        {
            var result = await _geoService.GetRegeoAsync(location, poitype, batch, radius, extensions, roadlevel, homeorcorp);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }
    }
}

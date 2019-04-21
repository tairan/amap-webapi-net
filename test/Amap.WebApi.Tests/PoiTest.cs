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
    public class PoiTest : TestBase
    {
        private readonly IPoiService _poiService;

        public PoiTest()
        {
            _poiService = ServiceProvider.GetRequiredService<IPoiService>();
        }

        [Theory]
        [InlineData("B0FFFAB6J2")]
        public async Task GetPoiByIdAsync_Success(string id)
        {
            var result = await _poiService.GetPoiByIdAsync(id);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }

        [Theory]
        [InlineData("116.460988,40.006919|116.48231,40.007381;116.47516,39.99713|116.472596,39.985227|116.45669,39.984989|116.460988,40.006919")]
        public async Task GetPoiByPolygonAsync_Success(string polygon)
        {
            var result = await _poiService.GetPoiByPolygonAsync(polygon);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }

        [Theory]
        [InlineData("116.473168,39.993015")]
        public async Task GetPoiByAroundAsync_Success(string location)
        {
            var result = await _poiService.GetPoiByAroundAsync(location);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }

        [Theory]
        [InlineData("北京大学")]
        public async Task GetPoiByTextAsync_Success(string keywords)
        {
            var result = await _poiService.GetPoiByTextAsync(keywords);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }
    }
}

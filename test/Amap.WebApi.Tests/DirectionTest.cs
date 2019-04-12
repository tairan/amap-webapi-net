using System;
using System.Threading.Tasks;
using Amap.WebApi.Shared;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace Amap.WebApi.Tests
{
    public class DirectionTest : TestBase
    {
        private readonly IDirectionService _directionService;

        public DirectionTest()
        {
            _directionService = ServiceProvider.GetRequiredService<IDirectionService>();
        }

        [Theory]
        [InlineData("116.481028,39.989643", "116.434446,39.90816")]
        public async Task GetWalkingAsync_Success(string origin, string destination)
        {
            var result = await _directionService.GetWalkingAsync(origin, destination);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }

        [Theory]
        [InlineData("116.481028,39.989643", "116.434446,39.90816", "北京", "北京", 0, 0)]
        public async Task GetTransitAsync_Success(string origin, string destination, string city, string cityd, int strategy, int nightflag)
        {
            var date = DateTime.Today;
            var time = DateTime.Now;
            var result = await _directionService.GetTransitAsync(origin, destination, city, cityd, date, time, strategy, nightflag);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }

        [Theory]
        [InlineData("116.481028,39.989643", "116.434446,39.90816", "all")]
        public async Task GetDrivingAsync_Success(string origin, string destination, string extension)
        {
            var result = await _directionService.GetDrivingAsync(origin, destination, extension);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }

        [Theory]
        [InlineData("116.434307,39.90909", "116.434446,39.90816")]
        public async Task GetBicyclingAsync_Success(string origin, string destination)
        {
            var result = await _directionService.GetBicyclingAsync(origin, destination);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.ErrorCode == Success_V4);
        }

        [Theory]
        [InlineData("116.434307,39.90909", "116.434446,39.90816", 2)]
        public async Task GetTruckAsync_Success(string origin, string destination, int size)
        {
            var result = await _directionService.GetTruckAsync(origin, destination, size);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.ErrorCode == Success_V4);
        }

        [Theory]
        [InlineData("116.481028,39.989643|114.481028,39.989643|115.481028,39.989643", "114.465302,40.004717", 1)]
        public async Task GetDistanceAsync_Success(string origins, string destination, int size)
        {
            var result = await _directionService.GetDistanceAsync(origins, destination, size);
            var response = JsonConvert.DeserializeObject<ServiceResponse>(result);

            Assert.True(response.Status == Success_V3);
        }
    }
}

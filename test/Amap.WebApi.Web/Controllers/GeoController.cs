using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Amap.WebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        private readonly IGeoService _geocode;

        public GeoController(IGeoService geocode)
        {
            _geocode = geocode;
        }

        [HttpGet]
        [Route("geo")]
        public async Task<IActionResult> GetGeoAsync()
        {
            return Ok(await _geocode.GetGeoAsync("北京市朝阳区阜通东大街6号"));
        }

        [HttpGet]
        [Route("regeo")]
        public async Task<IActionResult> GetReGeoAsync()
        {
            return Ok(await _geocode.GetRegeoAsync("116.481488,39.990464", "商务写字楼"));
        }
    }
}

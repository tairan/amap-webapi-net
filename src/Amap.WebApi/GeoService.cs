using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Amap.WebApi
{
    public class GeoService : ServiceClient, IGeoService
    {
        private readonly ILogger _logger;

        public GeoService(
            IOptionsSnapshot<AmapOptions> options,
            IHttpClientFactory httpClientFactory)
            : base(options, httpClientFactory)
        {
        }

        public GeoService(
            IOptionsSnapshot<AmapOptions> options,
            IHttpClientFactory httpClientFactory,
            ILoggerFactory loggerFactory)
            : this(options, httpClientFactory)
        {
            _logger = loggerFactory.CreateLogger<GeoService>();
        }

        public async Task<string> GetGeoAsync(string address, string city = "", bool batch = false)
        {

            var dict = new Dictionary<string, object>
            {
                { "address", address },
                { "batch", batch }
            };

            if (!string.IsNullOrWhiteSpace(city))
            {
                dict.Add("city", city);
            }

            var query = dict.Concat(_defaultQueries)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString().ToLower());

            query.Add("sig", await SignAsync(query));

            return await GetAsync(QueryHelpers.AddQueryString("/v3/geocode/geo", query));
        }

        public async Task<string> GetRegeoAsync(string location, string poitype, bool batch = false, int radius = 1000, string extensions = "base", int roadlevel = 0, int homeorcorp = 0)
        {
            var dict = new Dictionary<string, object>
            {
                { "location", location },
                { "batch", batch },
                { "radius", radius }
            };

            if (extensions.ToLower().Equals("all"))
            {
                dict.Add("extensions", extensions);
                dict.Add("roadlevel", roadlevel);
                dict.Add("homeorcorp", homeorcorp);

                if (!string.IsNullOrWhiteSpace(poitype))
                {
                    dict.Add("poitype", poitype);
                }
            }

            var query = dict.Concat(_defaultQueries)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString().ToLower());

            query.Add("sig", await SignAsync(query));

            return await GetAsync(QueryHelpers.AddQueryString("/v3/geocode/regeo", query));
        }
    }
}

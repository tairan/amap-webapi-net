using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Amap.WebApi
{
    public class PoiService : ServiceClient, IPoiService
    {
        public PoiService(
            IOptionsSnapshot<AmapOptions> options,
            HttpClient httpClient)
            : base(options, httpClient)
        {
        }

        public async Task<string> GetPoiByAroundAsync(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentNullException(nameof(location));
            }

            var dict = new Dictionary<string, object>
            {
                { "location", location }
            };

            return await SignAndGetAsync("/v3/place/around", dict);
        }

        public async Task<string> GetPoiByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var dict = new Dictionary<string, object>
            {
                { "id", id }
            };

            return await SignAndGetAsync("/v3/place/detail", dict);
        }

        public async Task<string> GetPoiByPolygonAsync(string polygon)
        {
            if (string.IsNullOrWhiteSpace(polygon))
            {
                throw new ArgumentNullException(nameof(polygon));
            }

            var dict = new Dictionary<string, object>
            {
                { "polygon", polygon }
            };

            return await SignAndGetAsync("/v3/place/polygon", dict);
        }

        public async Task<string> GetPoiByTextAsync(string keywords)
        {
            if (string.IsNullOrWhiteSpace(keywords))
            {
                throw new ArgumentNullException(nameof(keywords));
            }

            var dict = new Dictionary<string, object>
            {
                { "keywords", keywords }
            };

            return await SignAndGetAsync("/v3/place/text", dict);
        }
    }
}

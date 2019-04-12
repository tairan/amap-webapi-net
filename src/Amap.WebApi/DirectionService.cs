using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Amap.WebApi
{
    public class DirectionService : ServiceClient, IDirectionService
    {
        private readonly ILogger _logger;

        public DirectionService(
            IOptionsSnapshot<AmapOptions> options,
            IHttpClientFactory httpClientFactory)
            : base(options, httpClientFactory)
        {
            _logger = NullLogger.Instance;
        }

        public DirectionService(
            IOptionsSnapshot<AmapOptions> options,
            IHttpClientFactory httpClientFactory,
            ILoggerFactory loggerFactory)
            : this(options, httpClientFactory)
        {
            _logger = loggerFactory.CreateLogger<DirectionService>();
        }

        public async Task<string> GetWalkingAsync(string origin, string destination)
        {
            var dict = new Dictionary<string, object>
            {
                { "origin", origin },
                { "destination", destination }
            };

            return await SignAndGetAsync("/v3/direction/walking", dict);
        }

        public async Task<string> GetTransitAsync(string origin, string destination, string city, string cityd, DateTime date, DateTime time, int strategy = 0, int nightflag = 0)
        {
            var dict = new Dictionary<string, object>
            {
                { "origin", origin },
                { "destination", destination },
                { "city", city },
                { "cityd", cityd },
                { "strategy", strategy },
                { "nightflag", nightflag }
            };

            if (date == null)
            {
                date = DateTime.Today;
            }

            dict.Add("date", date.ToString("yyyy-MM-dd"));

            if (time == null)
            {
                time = DateTime.Now;
            }

            dict.Add("time", time.ToString("HH:mm"));

            return await SignAndGetAsync("/v3/direction/transit/integrated", dict);
        }

        public async Task<string> GetDrivingAsync(string origin, string destination, string extension)
        {
            var dict = new Dictionary<string, object>
            {
                { "origin", origin },
                { "destination", destination },
                { "extension", extension }
            };

            return await SignAndGetAsync("/v3/direction/driving", dict);
        }

        public async Task<string> GetBicyclingAsync(string origin, string destination)
        {
            var dict = new Dictionary<string, object>
            {
                { "origin", origin },
                { "destination", destination }
            };

            return await SignAndGetAsync("/v4/direction/bicycling", dict);
        }

        public async Task<string> GetTruckAsync(string origin, string destination, int size = 2)
        {
            var dict = new Dictionary<string, object>
            {
                { "origin", origin },
                { "destination", destination },
                { "size", size }
            };

            return await SignAndGetAsync("/v4/direction/truck", dict);
        }

        public async Task<string> GetDistanceAsync(string origins, string destination, int type = 1)
        {
            var dict = new Dictionary<string, object>
            {
                { "origins", origins },
                { "destination", destination },
                { "type", type }
            };

            return await SignAndGetAsync("/v3/distance", dict);
        }
    }
}

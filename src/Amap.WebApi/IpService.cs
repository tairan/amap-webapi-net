using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Amap.WebApi
{
    public class IpService : ServiceClient, IIpService
    {
        public IpService(IOptionsSnapshot<AmapOptions> options, IHttpClientFactory httpClientFactory)
            : base(options, httpClientFactory)
        {
        }

        public async Task<string> GetIpAsync(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                throw new ArgumentNullException(nameof(ip));
            }

            var dict = new Dictionary<string, object>
            {
                { "ip", ip }
            };

            return await SignAndGetAsync("/v3/ip", dict);
        }
    }
}

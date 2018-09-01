using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Amap.WebApi
{
    public class Client
    {
        private readonly HttpClient _httpClient;
        private readonly Config _config;

        public Client(Config config)
        {
            _config = config;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(config.Host);
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _httpClient.GetAsync(url + "&key=" + _config.Key);
        }
    }
}

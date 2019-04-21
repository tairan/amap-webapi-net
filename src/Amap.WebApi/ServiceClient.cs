using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace Amap.WebApi
{
    public abstract class ServiceClient
    {
        private const string _name = "AMAP_HTTPCLIENT";
        protected readonly HttpClient _client;
        protected readonly AmapOptions _options;
        protected readonly Dictionary<string, object> _defaultQueries;

        public ServiceClient(
            IOptionsSnapshot<AmapOptions> options,
            IHttpClientFactory httpClientFactory)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _options = options.Value;

            _client = httpClientFactory.CreateClient(_name);

            _client.BaseAddress = new Uri(options.Value.Host);

            _defaultQueries = new Dictionary<string, object>
            {
                { "key", options.Value.Key },
                { "output", "json" }
            };
        }

        protected async Task<string> GetAsync(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            return await _client.GetStringAsync(uri);
        }

        protected async Task<string> PostAsync(string uri, HttpContent content)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var response = await _client.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<string> SignAsync(IDictionary<string, string> dict)
        {
            using (var md5 = MD5.Create())
            {
                var plain = string.Join("&", dict.OrderBy(kvp => kvp.Key).Select(kvp => $"{kvp.Key}={kvp.Value}")) + _options.Key;
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(plain));
                return await Task.FromResult(string.Join("", hash.Select(b => b.ToString("x2"))));
            }
        }

        protected async Task<string> SignAndGetAsync(string path, IDictionary<string , object> query)
        {
            var data = query.Concat(_defaultQueries)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString().ToLower());

            data.Add("sig", await SignAsync(data));

            return await GetAsync(QueryHelpers.AddQueryString(path, data));
        }
    }
}

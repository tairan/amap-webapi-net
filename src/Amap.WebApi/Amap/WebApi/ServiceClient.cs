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
    public abstract class ServiceClient : IServiceClient
    {
        protected readonly Dictionary<string, object> _defaultQueries;

        public ServiceClient(
            IOptionsSnapshot<AmapOptions> options,
            HttpClient httpClient)
        {
            Options = options.Value;

            HttpClient = httpClient;
            HttpClient.BaseAddress = new Uri(Options.Host);

            _defaultQueries = new Dictionary<string, object>
            {
                { "key", Options.Key },
                { "output", "json" }
            };
        }

        public HttpClient HttpClient { get; }

        public AmapOptions Options { get; }

        protected async Task<string> GetAsync(string uri)
        {
            if (string.IsNullOrWhiteSpace(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var response = await HttpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
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

            var response = await HttpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<string> SignAsync(IDictionary<string, string> dict)
        {
            using (var md5 = MD5.Create())
            {
                var plain = string.Join("&", dict.OrderBy(kvp => kvp.Key).Select(kvp => $"{kvp.Key}={kvp.Value}")) + Options.Key;
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(plain));
                return await Task.FromResult(string.Join("", hash.Select(b => b.ToString("x2"))));
            }
        }

        protected async Task<string> SignAndGetAsync(string path, IDictionary<string, object> query)
        {
            var data = query.Concat(_defaultQueries)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString().ToLower());

            data.Add("sig", await SignAsync(data));

            return await GetAsync(QueryHelpers.AddQueryString(path, data));
        }
    }
}

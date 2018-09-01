using System.Net.Http;
using System.Threading.Tasks;

namespace Amap.WebApi
{
    public class Geocode
    {
        private readonly Client _client;
        public Geocode(Client client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetGeoAsync(string address, string city = "", bool batch = false, string sigure = "", string output = "json", string callback = "")
        {
            var request = "/v3/geocode/geo?";

            request += "address=" + address;
            if (string.IsNullOrEmpty(city))
            {
                request += "&city=" + city;
            }
            if (batch)
            {
                request += "&batch=true";
            }
            if (string.IsNullOrEmpty(sigure))
            {
                request += "&sig=" + sigure;
            }
            request += "&output=" + output;
            if (string.IsNullOrEmpty(callback))
            {
                request += "&callback=" + callback;
            }

            return await _client.GetAsync(request);
        }
    }
}

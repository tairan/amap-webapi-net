using System;
using Newtonsoft.Json;

namespace Amap.WebApi.Shared
{
    [JsonObject]
    public class Response
    {
        [JsonProperty]
        public string Status { get; set; }

        [JsonProperty]
        public int Count { get; set; }

        [JsonProperty]
        public string Info { get; set; }
    }
}

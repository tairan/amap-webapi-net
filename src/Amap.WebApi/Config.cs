using System;

namespace Amap.WebApi
{
    public class Config
    {
        public Config(string host, string key)
        {
            Host = host;
            Key = key;
        }

        public string Key { get; set; }
        public string Host { get; set; }
    }
}

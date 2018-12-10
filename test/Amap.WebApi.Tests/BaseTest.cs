using System;
using Xunit;

namespace Amap.WebApi.Tests
{
    public class BaseTest
    {
        protected const string Host = "";
        protected const string Key = "";

        protected readonly Client client;

        public BaseTest()
        {
            Config config = new Config(Host, Key);
            client = new Client(config);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestAsync()
        {
            var hello = await client.GetAsync("");
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amap.WebApi
{
    public static class GeocodeExtensions
    {
        public async static Task Geo(this Client client)
        {
            await client.GetAsync("");
        }

        public async static Task Regeo(this Client client)
        {
            await client.GetAsync("");
        }
    }
}

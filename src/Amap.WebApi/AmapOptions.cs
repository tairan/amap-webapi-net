using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amap.WebApi
{
    public class AmapOptions
    {
        public string Host { get; set; } = "https://restapi.amap.com/";

        public string Key { get; set; }
    }
}

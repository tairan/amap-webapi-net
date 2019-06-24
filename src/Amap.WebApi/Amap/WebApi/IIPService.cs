using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amap.WebApi
{
    public interface IIpService
    {
        Task<string> GetIpAsync(string ip);
    }
}

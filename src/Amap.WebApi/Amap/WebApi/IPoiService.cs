using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amap.WebApi
{
    public interface IPoiService
    {
        Task<string> GetPoiByTextAsync(string keywords);

        Task<string> GetPoiByAroundAsync(string location);

        Task<string> GetPoiByPolygonAsync(string polygon);

        Task<string> GetPoiByIdAsync(string id);
    }
}

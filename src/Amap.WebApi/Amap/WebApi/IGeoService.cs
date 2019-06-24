using System.Threading.Tasks;

namespace Amap.WebApi
{
    public interface IGeoService
    {
        Task<string> GetGeoAsync(string address, string city = "", bool batch = false);

        Task<string> GetRegeoAsync(string location, string poitype, bool batch = false, int radius = 1000, string extensions = "base", int roadlevel = 0, int homeorcorp = 0);
    }
}

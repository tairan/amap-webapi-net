using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amap.WebApi
{
    public interface IDirectionService
    {
        Task<string> GetWalkingAsync(string origin, string destination);

        Task<string> GetTransitAsync(string origin, string destination, string city, string cityd, DateTime date, DateTime time, int strategy = 0, int nightflag = 0);

        // TODO: Not completely implemented
        Task<string> GetDrivingAsync(string origin, string destination, string extension);

        Task<string> GetBicyclingAsync(string origin, string destination);

        // TODO: Not completely implemented
        Task<string> GetTruckAsync(string origin, string destination, int size = 2);

        // TODO: Not completely implemented
        Task<string> GetDistanceAsync(string origins, string destination, int type = 1);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EmergencyAppSL.Services
{
    public interface ILocationService
    {
        Task<Tuple<bool, string>> CheckLocationPermission();

        Task<Location> GetLocation();

        Task<string> GetAddressFromLocation(Location location);
    }
}

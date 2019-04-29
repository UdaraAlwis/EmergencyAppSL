using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace EmergencyAppSL.Services
{
    public class LocationService : ILocationService
    {
        public async Task<Tuple<bool, string>> CheckLocationPermission()
        {
            var locationPermissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

            if (locationPermissionStatus != PermissionStatus.Granted)
            {
                return Tuple.Create(true, "Location Permission Enabled!");
            }
            else
            {
                return Tuple.Create(false, "Location Permission Disabled!");
            }
        }

        public async Task<Tuple<bool, string>> RequestLocationPermission()
        {
            var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
            
            return await CheckLocationPermission();
        }

        public async Task<string> GetAddressFromLocation(Location location)
        {
            if (location != null)
            {
                var geoCoder = new Geocoder();
                var position = new Position(location.Latitude, location.Longitude);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                
                return possibleAddresses.FirstOrDefault();
            }

            return null;
        }

        public async Task<Location> GetLocation()
        {
            var permissionStatis = await CheckLocationPermission();

            if (permissionStatis.Item1)
                return await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));

            return null;
        }
    }
}

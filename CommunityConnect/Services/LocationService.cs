// Services/LocationService.cs
using System.Diagnostics;

namespace CommunityConnect.Services
{
    public class LocationService : ILocationService
    {
        private readonly IGeolocation _geolocation;
        private readonly IPermissions _permissions;

        public LocationService(IGeolocation geolocation, IPermissions permissions)
        {
            _geolocation = geolocation;
            _permissions = permissions;
        }

        public async Task<Location> GetCurrentLocationAsync()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if(status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if(status != PermissionStatus.Granted)
                        throw new UnauthorizedAccessException("Location permission not granted");
                }

                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Best,
                    Timeout = TimeSpan.FromSeconds(5)
                });

                return location;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Unable to get location: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> IsLocationPermissionGrantedAsync()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            return status == PermissionStatus.Granted;
        }

        public async Task<IEnumerable<Location>> GetNearbyHotspotsAsync(double radius)
        {
            // Implementation for getting nearby hotspots
            throw new NotImplementedException();
        }

        public async Task<double> CalculateDistanceToIncidentAsync(Location incidentLocation)
        {
            // Implementation for calculating distance
            throw new NotImplementedException();
        }
    }
}
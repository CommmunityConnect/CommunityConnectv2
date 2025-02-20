namespace CommunityConnect.Services
{
    public interface ILocationService
    {
        Task<Location> GetCurrentLocationAsync();
        Task<bool> IsLocationPermissionGrantedAsync();
        Task<IEnumerable<Location>> GetNearbyHotspotsAsync(double radius);
        Task<double> CalculateDistanceToIncidentAsync(Location incidentLocation);
    }
}
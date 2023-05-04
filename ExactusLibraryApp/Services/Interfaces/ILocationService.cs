using ExactusLibraryApp.Models;

namespace ExactusLibraryApp.Services.Interfaces
{
    public interface ILocationService
    {
        bool Create(Location model);

        bool Edit(Location model);

        bool Delete(int id);

        Location GetLocationById(int id);

        IEnumerable<Location> GetAllLocations();
    }
}

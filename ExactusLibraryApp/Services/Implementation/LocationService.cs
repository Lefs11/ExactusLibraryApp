using ExactusLibraryApp.Data;
using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;

namespace ExactusLibraryApp.Services.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _db;
        public LocationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Location obj)
        {
            try
            {
                _db.Locations.Add(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Location obj)
        {
            try
            {
                _db.Locations.Update(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Location GetLocationById(int id)
        {
            return _db.Locations.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var data = GetLocationById(id);
                if (data == null)
                {
                    return false;
                }
                _db.Locations.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _db.Locations.ToList();
        }
    }
}

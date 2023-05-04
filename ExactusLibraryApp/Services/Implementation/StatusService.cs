using ExactusLibraryApp.Data;
using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ExactusLibraryApp.Services.Implementation
{
    public class StatusService : IStatusService
    {
        private readonly ApplicationDbContext _db;
        public StatusService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Status obj)
        {
            try
            {
                _db.Statuses.Add(obj);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Status obj)
        {
            try
            {
                _db.Statuses.Update(obj);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Status GetStatusById(int id)
        {
            return _db.Statuses.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var data = GetStatusById(id);
                if(data == null)
                {
                    return false;
                }
                _db.Statuses.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return _db.Statuses.ToList();
        }

    }
}

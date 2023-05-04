using ExactusLibraryApp.Data;
using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;

namespace ExactusLibraryApp.Services.Implementation
{
    public class TypeService : ITypeService
    {
        private readonly ApplicationDbContext _db;
        public TypeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(BookType obj)
        {
            try
            {
                _db.BookTypes.Add(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(BookType obj)
        {
            try
            {
                _db.BookTypes.Update(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public BookType GetTypeById(int id)
        {
            return _db.BookTypes.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var data = GetTypeById(id);
                if (data == null)
                {
                    return false;
                }
                _db.BookTypes.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<BookType> GetAllTypes()
        {
            return _db.BookTypes.ToList();
        }
    }
}

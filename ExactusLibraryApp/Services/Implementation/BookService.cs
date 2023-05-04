using ExactusLibraryApp.Data;
using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;

namespace ExactusLibraryApp.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _db;
        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Book obj)
        {
            try
            {
                _db.Books.Add(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Book obj)
        {
            try
            {
                _db.Books.Update(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Book GetBookById(int id)
        {
            return _db.Books.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var data = GetBookById(id);
                if (data == null)
                {
                    return false;
                }
                _db.Books.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var data = (from book in _db.Books
                        join status in _db.Statuses on book.StatusId equals status.Id
                        join location in _db.Locations on book.LocationId equals location.Id
                        join type in _db.BookTypes on book.TypeId equals type.Id
                        select new Book
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = book.Author,
                            Owner = book.Owner,
                            CheckedOutBy = book.CheckedOutBy,
                            CheckedOutDate = book.CheckedOutDate,
                            StatusId = book.StatusId,
                            LocationId = book.LocationId,
                            TypeId = book.TypeId,
                            StatusName = status.StatusName,
                            LocationName = location.LocationName,
                            TypeName = type.TypeName
                        }).ToList();
            return data;
        }
    }
}

using ExactusLibraryApp.Models;

namespace ExactusLibraryApp.Services.Interfaces
{
    public interface IBookService
    {
        bool Create(Book model);

        bool Edit(Book model);

        bool Delete(int id);

        Book GetBookById(int id);

        IEnumerable<Book> GetAllBooks();
    }
}

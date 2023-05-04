using ExactusLibraryApp.Models;

namespace ExactusLibraryApp.Services.Interfaces
{
    public interface ITypeService
    {
        bool Create(BookType model);

        bool Edit(BookType model);

        bool Delete(int id);

        BookType GetTypeById(int id);

        IEnumerable<BookType> GetAllTypes();
    }
}

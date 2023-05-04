using ExactusLibraryApp.Models;

namespace ExactusLibraryApp.Services.Interfaces
{
    public interface IStatusService
    {
        bool Create(Status model);

        bool Edit(Status model);

        bool Delete(int id);

        Status GetStatusById(int id);

        IEnumerable<Status> GetAllStatus();
    }
}

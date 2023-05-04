using ExactusLibraryApp.Models;

namespace ExactusLibraryApp.Services.Interfaces
{
    public interface ICommentService
    {
        bool Create(Comment model);

        bool Edit(Comment model);

        Comment GetCommentById(int id);

        IEnumerable<Comment> GetAllComments();

    }
}

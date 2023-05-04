using ExactusLibraryApp.Data;
using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;

namespace ExactusLibraryApp.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _db;
        public CommentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Comment obj)
        {
            try
            {
                _db.Comments.Add(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Comment obj)
        {
            try
            {
                _db.Comments.Update(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Comment GetCommentById(int id)
        {
            return _db.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _db.Comments.ToList();
        }
    }
}

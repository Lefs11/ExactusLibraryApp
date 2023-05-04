using System.ComponentModel.DataAnnotations;

namespace ExactusLibraryApp.Models
{
    public class BookType
    {
        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}

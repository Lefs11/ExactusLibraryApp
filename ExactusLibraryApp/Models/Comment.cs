using System.ComponentModel.DataAnnotations;

namespace ExactusLibraryApp.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public string Comments { get; set; }
    }
}

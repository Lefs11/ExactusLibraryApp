using System.ComponentModel.DataAnnotations;

namespace ExactusLibraryApp.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string StatusName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ExactusLibraryApp.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string LocationName { get; set; }
    }
}

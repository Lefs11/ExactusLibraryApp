using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace ExactusLibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Owner { get; set; }

        public string? CheckedOutBy { get; set; }

        public DateTime? CheckedOutDate { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public string CommentId { get; set; }

        [NotMapped]
        public string ? StatusName { get; set; }

        [NotMapped]
        public string ? LocationName { get; set; }

        [NotMapped]
        public string ? TypeName { get; set; }

        [NotMapped]
        public string ? CommentName { get; set; }

        [NotMapped]
        public List<SelectListItem> ? StatusList { get; set; }

        [NotMapped]
        public List<SelectListItem> ? LocationList { get; set; }

        [NotMapped]
        public List<SelectListItem> ? TypeList { get; set; }

        [NotMapped]
        public List<SelectListItem> ? CommentsList { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExactusLibraryApp.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        public int BookId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ReturnDate { get; set; }

        [NotMapped]
        public string ? BookName { get; set; }

        [NotMapped]
        public List<SelectListItem> ? BooksList { get; set; }

        public Loan()
        {
            StartDate = DateTime.Now;
        }

        public void SetReturnDate()
        {
            ReturnDate = DateTime.Now;
        }
    }
}

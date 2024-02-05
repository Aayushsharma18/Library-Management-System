using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
    }
}

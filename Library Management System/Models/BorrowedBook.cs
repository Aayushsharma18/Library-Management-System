using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class BorrowedBook
    {
        [Key]
        public int BorrowedId { get; set; }
        [Required]
        public int BookId {  get; set; }
        [Required]
        public int UserId { get;set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class UserLib
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}

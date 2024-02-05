using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks {  get; set; }
        public DbSet<UserLib> UserLibs { get; set; }

    }
}

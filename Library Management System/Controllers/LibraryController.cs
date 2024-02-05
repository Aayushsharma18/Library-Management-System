using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryDbContext _context;

        public LibraryController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var getallbook = _context.BorrowedBooks.FromSqlRaw("getBorrowedBooksDetails").ToList();
            return View(getallbook);
        }

        public IActionResult getBorrowedBook(int? id)
        {
            var userById = _context.BorrowedBooks.FromSqlRaw($"getBorrowedBooksById {id}").AsEnumerable().FirstOrDefault();
            return View(userById);
        }

        [HttpPost]
        public async Task<IActionResult> updateBorrowedBooks(int id, string userid, string bookid, DateTime bdate, DateTime rdate)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter(){ ParameterName="@id",SqlDbType=System.Data.SqlDbType.VarChar,Value=id},
                new SqlParameter(){ ParameterName="@userid",SqlDbType=System.Data.SqlDbType.VarChar,Value=userid},
                new SqlParameter(){ ParameterName="@bookid",SqlDbType=System.Data.SqlDbType.VarChar,Value=bookid},
                new SqlParameter(){ ParameterName="@bdate",SqlDbType=System.Data.SqlDbType.DateTime,Value=bdate},
                new SqlParameter(){ ParameterName="@rdate",SqlDbType=System.Data.SqlDbType.DateTime,Value=rdate}
            };

            var updateLib = await _context.Database.ExecuteSqlRawAsync($"exec updateBorrowedBook @id,@userid,@bookid,@bdate,@rdate", param);
            if (updateLib == 1)
            {
                return View(updateLib);
            }
            else
            {
                return View(updateLib);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, string userid, string bookid, DateTime bdate, DateTime rdate)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter(){ ParameterName="@id", SqlDbType=System.Data.SqlDbType.VarChar, Value=id},
                new SqlParameter(){ ParameterName="@userid", SqlDbType=System.Data.SqlDbType.VarChar, Value=userid},
                new SqlParameter(){ ParameterName="@bookid", SqlDbType=System.Data.SqlDbType.VarChar, Value=bookid},
                new SqlParameter(){ ParameterName="@bdate", SqlDbType=System.Data.SqlDbType.DateTime, Value=bdate},
                new SqlParameter(){ ParameterName="@rdate", SqlDbType=System.Data.SqlDbType.DateTime, Value=rdate}
            };

            if (id == 0)
            {
                await _context.Database.ExecuteSqlRawAsync("exec insertBorrowedBook @userid, @bookid, @bdate, @rdate", param);
            }
            else
            {
                await _context.Database.ExecuteSqlRawAsync("exec updateBorrowedBook @id, @userid, @bookid, @bdate, @rdate", param);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("DeleteStudent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudentConfirmed(int id)
        {
            try
            {
                var student = await _context.BorrowedBooks.FindAsync(id);
                if (student == null)
                {
                    return View("NotFound");
                }

                _context.BorrowedBooks.Remove(student);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
        }

    }
}

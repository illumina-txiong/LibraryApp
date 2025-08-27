using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Services;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private static LibraryService _service = new LibraryService();

        [HttpGet("books")]
        public IEnumerable<Book> GetAllBooks()
        {
            return _service.Books;
        }

        [HttpGet("users")]
        public IEnumerable<User> GetAllUsers()
        {
            return _service.Users;
        }

        [HttpPost("borrow/{userId}/{bookId}")]
        public string BorrowBook(int userId, int bookId)
        {
            return _service.BorrowBook(userId, bookId);
        }

        [HttpPost("return/{userId}/{bookId}")]
        public string ReturnBook(int userId, int bookId)
        {
            return _service.ReturnBook(userId, bookId);
        }

        [HttpGet("overdue/{userId}")]
        public List<Book> GetOverdueBooks(int userId)
        {
            return _service.CheckOverdue(userId);
        }
    }
}

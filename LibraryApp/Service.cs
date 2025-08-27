using LibraryApi.Models;

namespace LibraryApi.Services
{
    public class LibraryService
    {
        public List<Book> Books = new List<Book>()
        {
            new Book(){ Id=1, Title="Ikigai" },
            new Book(){ Id=2, Title="The Staff Engineer's Path" },
            new Book(){ Id=3, Title="You Don't Know JavaScript", IsBorrowed=true, BorrowedDate=DateTime.Now.AddDays(-40) }
        };

        public List<User> Users = new List<User>()
        {
            new User(){ Id=1, Name="Alice" },
            new User(){ Id=2, Name="Bob", BorrowLimit=1 }
        };

        public string BorrowBook(int userId, int bookId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            var book = Books.FirstOrDefault(b => b.Id == bookId);

            if (user == null || book == null) return "User or book not found";

            if (user.BorrowedBookIds.Count >= user.BorrowLimit)
            {
                return "User reached borrow limit";
            }

            if (book.IsBorrowed)
            {
                return "Book already borrowed";
            }

            book.IsBorrowed = true;
            book.BorrowedDate = DateTime.Now;
            user.BorrowedBookIds.Add(book.Id);

            return "Book borrowed successfully";
        }

        public string ReturnBook(int userId, int bookId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            var book = Books.FirstOrDefault(b => b.Id == bookId);

            if (user == null || book == null) return "User or book not found";

            if (!book.IsBorrowed)
            {
                return "Book was not borrowed";
            }

            book.IsBorrowed = false;
            return "Book returned successfully";
        }

        public List<Book> CheckOverdue(int userId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return new List<Book>();
            return Books.Where(b => b.IsBorrowed && user.BorrowedBookIds.Contains(b.Id) && b.BorrowedDate.AddDays(30) < DateTime.Now).ToList();
        }
    }
}

namespace LibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime BorrowedDate { get; set; }
        public bool IsBorrowed { get; set; }
    }
}

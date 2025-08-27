namespace LibraryApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BorrowLimit { get; set; } = 2;
        public List<int> BorrowedBookIds { get; set; } = new List<int>();
    }
}

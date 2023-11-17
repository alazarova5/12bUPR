namespace BooksStoreApplication.Models.Book
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string? Picture { get; set; }
        public DateTime YearOfPublication { get; set; }
        public double Price { get; set; }
    }
}

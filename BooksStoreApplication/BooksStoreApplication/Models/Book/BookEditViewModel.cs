using System.ComponentModel.DataAnnotations;

namespace BooksStoreApplication.Models.Book
{
    public class BookEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "BookName")]
        public string BookName { get; set; } = null;

        [Required]
        [MaxLength(30)]
        [Display(Name = "Author")]
        public string Author { get; set; } = null;

        [Required]
        [MaxLength(30)]
        [Display(Name = "Genre")]
        public string Genre { get; set; } = null;

        [Required]
        [MaxLength(30)]
        [Display(Name = "Book Picture")]
        public string? Picture { get; set; }

        [Required]
        [Display(Name = "Year of publication")]
        public DateTime YearOfPublication { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}

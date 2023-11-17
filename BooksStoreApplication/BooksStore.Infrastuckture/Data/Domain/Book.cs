using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.Infrastucture.Data.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string BookName { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Genre { get; set; } = null!;

        public string Picture { get; set; } = null!;
        public DateTime YearOfPublication { get; set; }

        [Required]
        [Range(5, 200)]
        public double Price { get; set; }
    }
}

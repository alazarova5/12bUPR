using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BooksStore.Infrastucture.Data.Domain;

namespace BooksStore.Core.Contracts
{
    public interface IBookService
    {
        bool Create(string bookName, string author, string genre, string pictute, int yearOfPublication, double price);
        bool UpdateBook(string bookName, string author, string genre, string pictute, int yearOfPublication, double price);
        List<Book> GetBooks();
        bool RemobeBy(int bookId);
        List<Book> GetBooks(string searchStringBookName);
    }
}

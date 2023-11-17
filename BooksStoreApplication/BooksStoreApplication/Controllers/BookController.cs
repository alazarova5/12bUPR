using System.Linq.Expressions;

using BooksStore.Infrastucture.Data.Domain;

using BooksStoreApplication.Infrastucture.Data;
using BooksStoreApplication.Models.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreApplication.Controllers
{
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: BookController
        public ActionResult Index(string searchStringGenre, string searchStringPrice)
        {
            List<BookAllViewModel> books = _context.Books
                .Select(bookFromDb => new BookAllViewModel
                {
                    Id = bookFromDb.Id,
                    BookName = bookFromDb.BookName,
                    Author = bookFromDb.Author,
                    Genre = bookFromDb.Genre,
                    Picture = bookFromDb.Picture,
                    YearOfPublication = bookFromDb.YearOfPublication,
                    Price = bookFromDb.Price
                }).ToList();

            if (!String.IsNullOrEmpty(searchStringGenre) )
            {
                books = books.Where(b => b.Genre.Contains(searchStringGenre)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringGenre))
            {
                books = books.Where(b => b.Genre.Contains(searchStringGenre)).ToList();
            }
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book? item = _context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            BookDetailsViewModel book = new BookDetailsViewModel()
            {
                Id = item.Id,
                BookName = item.BookName,
                Author = item.Author,
                Genre = item.Genre,
                Picture = item.Picture,
                YearOfPublication = item.YearOfPublication,
                Price = item.Price
            };
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Book bookFromDb = new Book
                {
                    BookName = bindingModel.BookName,
                    Author = bindingModel.Author,
                    Genre = bindingModel.Genre,
                    Picture = bindingModel.Picture,
                    YearOfPublication = bindingModel.YearOfPublication,
                    Price = bindingModel.Price,
                };

                _context.Books.Add(bookFromDb);
                _context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }

        public IActionResult Success()
        {
            return this.View();
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book? item = _context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            BookEditViewModel book = new BookEditViewModel()
            {
                Id = item.Id,
                BookName = item.BookName,
                Author = item.Author,
                Genre = item.Genre,
                Picture = item.Picture,
                YearOfPublication = item.YearOfPublication,
                Price = item.Price
            };
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookEditViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book
                {
                    Id = id,
                    BookName = bindingModel.BookName,
                    Author = bindingModel.Author,
                    Genre = bindingModel.Genre,
                    Picture = bindingModel.Picture,
                    YearOfPublication = bindingModel.YearOfPublication,
                    Price = bindingModel.Price
                };

                _context.Books.Update(book);
                _context.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return View(bindingModel);
        }


        // GET: BookController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book? item = _context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            BookDetailsViewModel book = new BookDetailsViewModel()
            {
                Id = item.Id,
                BookName = item.BookName,
                Author = item.Author,
                Genre = item.Genre,
                Picture = item.Picture,
                YearOfPublication = item.YearOfPublication,
                Price = item.Price
            };

            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Book? item = _context.Books.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Books.Remove(item);
            _context.SaveChanges();
            return this.RedirectToAction("Index", "Book");
        }
    }
}


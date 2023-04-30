using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,AppDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }
       
        

        public IActionResult Index()
        {
            var books = _context.Books /*.ToList()*/
                .Include(m => m.Images)
                .Include(m => m.BookAuthors)
                .ThenInclude(m => m.Author)
                .ThenInclude(m => m.SocialPage)
                .Include(m => m.BookGenres)
                .ThenInclude(m => m.Genre)
                .ToList();


            return View(books);
        }


        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_context.Authors.ToList(), "Id", "AuthorName");
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            ViewBag.Authors = new SelectList(_context.Authors.ToList(), "Id", "AuthorName");
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "Id", "Name");

            Book newBook = new Book();
            newBook.Name = book.Name;
            newBook.Price = book.Price;

            foreach (var item in book.GenresIds)
            {
                BookGenre bookGenre = new BookGenre();
                bookGenre.Id = newBook.Id;
                bookGenre.GenreId = item;
                newBook.BookGenres.Add(bookGenre);
            }
            foreach (var item in book.Authorİds)
            {
                BookAuthor bookAuthor = new BookAuthor();
                bookAuthor.Id = newBook.Id;
                bookAuthor.AuthorId = item;
                newBook.BookAuthors.Add(bookAuthor);
            }

            newBook.Images.Add(new Image { Name = "test.png" });
            newBook.Images.Add(new Image { Name = "test2.png" });

            _context.Books.Add(newBook);
            _context.SaveChanges();
            return View();
        }
    }
}
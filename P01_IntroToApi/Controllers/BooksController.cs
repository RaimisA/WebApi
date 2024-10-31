using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_IntroToApi.Controllers.Models;

namespace P01_IntroToApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly List<Book> _books;

        public BooksController()
        {
            var author1 = new Author { Id = 1, Name = "J.R.R.", Surname = "Tolkien" };
            var author2 = new Author { Id = 2, Name = "J.K.", Surname = "Rowling" };
            var author3 = new Author { Id = 3, Name = "John", Surname = "Doe" };

            _books = new List<Book>
            {
                new Book { Id = 1, Title = "The Hobbit", Authors = new List<Author> { author1 }, PublishYear = 1937 },
                new Book { Id = 2, Title = "The Lord of the Rings", Authors = new List<Author> { author1 }, PublishYear = 1954 },
                new Book { Id = 3, Title = "The Silmarillion", Authors = new List<Author> { author1 }, PublishYear = 1977 },
                new Book { Id = 4, Title = "Harry Potter and the Philosopher's Stone", Authors = new List<Author> { author2 }, PublishYear = 1997 },
                new Book { Id = 5, Title = "Harry Potter and the Chamber of Secrets", Authors = new List<Author> { author2 }, PublishYear = 1998 },
                new Book { Id = 6, Title = "Harry Potter and the Prisoner of Azkaban", Authors = new List<Author> { author2 }, PublishYear = 1999 },
                new Book { Id = 7, Title = "Harry Potter and the Goblet of Fire", Authors = new List<Author> { author2 }, PublishYear = 2000 },
                new Book { Id = 8, Title = "Harry Potter and the Order of the Phoenix", Authors = new List<Author> { author2 }, PublishYear = 2003 },
                new Book { Id = 9, Title = "Harry Potter and the Half-Blood Prince", Authors = new List<Author> { author2 }, PublishYear = 2005 },
                new Book { Id = 10, Title = "Harry Potter and the Deathly Hallows", Authors = new List<Author> { author2 }, PublishYear = 2007 },
                new Book { Id = 11, Title = "Collaborative Book", Authors = new List<Author> { author1, author3 }, PublishYear = 2021 }
            };
        }
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _books;
        }
        [HttpGet("{id}")]
        public Book? book(int id)
        {
            return _books.Find(x => x.Id == id);
        }
        [HttpGet("GetByTitle")]
        public Book? GetByTitle(string title)
        {
            return _books.Find(x => x.Title == title);
        }

        [HttpGet("FilterBy")]
        public IEnumerable<Book> FilterBy(string title, string author)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(author))
            {
                throw new ArgumentException("nepateikti filtravimo parametrai");
            }
            return _books.Where(x => x.Title.Contains(title) || x.Authors.Any(a => a.Name == author || a.Surname == author));
        }

        [HttpGet("GetByAuthor")]
        public IEnumerable<Book> GetByAuthor(string author)
        {
            return _books.Where(x => x.Authors.Any(a => a.Name == author || a.Surname == author));
        }
    }
}

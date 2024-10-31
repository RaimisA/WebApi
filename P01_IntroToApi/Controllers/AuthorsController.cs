using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_IntroToApi.Controllers.Models;

namespace P01_IntroToApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly List<Author> _authors;
        private readonly List<Book> _books;

        public AuthorsController()
        {
            var author1 = new Author { Id = 1, Name = "Author 1", Surname = "Surname 1" };
            var author2 = new Author { Id = 2, Name = "Author 2", Surname = "Surname 2" };
            var author3 = new Author { Id = 3, Name = "Author 3", Surname = "Surname 3" };
            var author4 = new Author { Id = 4, Name = "Author 4", Surname = "Surname 4" };
            var author5 = new Author { Id = 5, Name = "Author 5", Surname = "Surname 5" };
            var author6 = new Author { Id = 6, Name = "Author 6", Surname = "Surname 6" };
            var author7 = new Author { Id = 7, Name = "Author 7", Surname = "Surname 7" };
            var author8 = new Author { Id = 8, Name = "Author 8", Surname = "Surname 8" };
            var author9 = new Author { Id = 9, Name = "Author 9", Surname = "Surname 9" };
            var author10 = new Author { Id = 10, Name = "Author 10", Surname = "Surname 10" };
            var author11 = new Author { Id = 11, Name = "Author 11", Surname = "Surname 11" };
            var author12 = new Author { Id = 12, Name = "Author 12", Surname = "Surname 12" };

            _authors = new List<Author>
            {
                author1, author2, author3, author4, author5, author6, author7, author8, author9, author10, author11, author12
            };

            _books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", Authors = new List<Author> { author1, author2 }, PublishYear = 2021 },
                new Book { Id = 2, Title = "Book 2", Authors = new List<Author> { author3, author4 }, PublishYear = 2020 },
                new Book { Id = 3, Title = "Book 3", Authors = new List<Author> { author1 }, PublishYear = 2019 },
                new Book { Id = 4, Title = "Book 4", Authors = new List<Author> { author6, author7 }, PublishYear = 2018 },
                new Book { Id = 5, Title = "Book 5", Authors = new List<Author> { author1, author9 }, PublishYear = 2017 },
                new Book { Id = 6, Title = "Book 6", Authors = new List<Author> { author4 }, PublishYear = 2016 },
                new Book { Id = 7, Title = "Book 7", Authors = new List<Author> { author10, author11 }, PublishYear = 2015 },
                new Book { Id = 8, Title = "Book 8", Authors = new List<Author> { author12, author10 }, PublishYear = 2014 }
            };
        }

        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return _authors;
        }

        [HttpGet("{id}")]
        public Author? GetAuthorById(int id)
        {
            return _authors.Find(x => x.Id == id);
        }

        [HttpGet("{id}/books")]
        public IEnumerable<Book>? GetBooksByAuthorId(int id)
        {
            return _books.Where(x => x.Authors.Any(author => author.Id == id));
        }

        [HttpGet("{id}/booksByAuthorAndTitle")]
        public IEnumerable<Book>? GetBooksByAuthorAndTitle([FromRoute] int id, [FromQuery] string? title)
        {
            return _books.Where(x => x.Authors.Any(author => author.Id == id) && (string.IsNullOrEmpty(title) || x.Title.Contains(title)));
        }
    }
}

using book_service.Data.Models;
using book_service.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace book_service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksService _bookSerivce;
        private readonly ILogger<BooksController>_logger;

        public BooksController(BooksService bookService, ILogger<BooksController> logger)
        {
            _bookSerivce = bookService;
            _logger = logger;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            _logger.LogInformation("GetAllBooks Called");
            var allBooks = _bookSerivce.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-all-books-ienumerable")]
        public IEnumerable<Book> GetAllBooksIEnumerable()
        {
            _logger.LogInformation("GetAllBooksIEnumerable Called");
            var books =  _bookSerivce.GetAllBooks();

            return books;
        }

        [HttpGet("get-all-books-iasyncenumerable")]
        public async IAsyncEnumerable<Book> GetAllBooksIAsyncEnumerable()
        {
            _logger.LogInformation("GetAllBooksIAsyncEnumerable Called");
            var books = _bookSerivce.GetAllBooksAsync();

            await foreach (var book in books)
            {
                yield return book;
            }
        }

        [HttpGet("get-book-by-id/{id}")]
        public Book GetBookById(int id)
        {
            var book = _bookSerivce.GetBookById(id);
            
            return book;
        }

        [HttpGet("get-book-by-id-iactionresult/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBookByIdIActionResult(int id)
        {
            if (!_bookSerivce.TryGetBook(id, out var book))
                return NotFound();

            return Ok(book);
        }

        [HttpGet("get-book-by-id-actionresult-book/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> GetBookByIdActionResultBook(int id)
        {
            if (!_bookSerivce.TryGetBook(id, out var book))
                return NotFound();

            return book;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookDTO book)
        {
            _bookSerivce.AddBook(book);
            return Ok();
        }

        [HttpPost("add-book-async")]
        [Consumes(MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBookAsync([FromBody] BookDTO book)
        {
            if (book.Title.Contains("?"))
                return BadRequest();

            await _bookSerivce.AddBookAsync(book);
            
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookDTO book)
        {
            var updatedBook = _bookSerivce.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById (int id)
        {
            _bookSerivce.DeleteBookById(id);
            return Ok();
        }
    }
}

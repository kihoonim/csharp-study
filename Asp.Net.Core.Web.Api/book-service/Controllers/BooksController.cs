using book_service.Data.Services;
using book_service.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_service.Controllers
{
    [Route("api/[controller]")]
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
            throw new Exception("Custom Error");
            var allBooks = _bookSerivce.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}/{desc}")]
        public IActionResult GetBookById(int id, string desc)
        {
            var book = _bookSerivce.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookSerivce.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
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

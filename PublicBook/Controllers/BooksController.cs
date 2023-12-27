using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicBook.Service;

namespace PublicBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync() 
        { 
            var book = await _bookService.GetAllBooksAsync();
            return Ok(book);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookAsunc([FromForm] BookDTO bookDto)
        {
            var book = await _bookService.CreateBookAsunc(bookDto);
            return Ok(book);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateBookAsunc([FromForm] UpdateBookDTO bookDto, int id)
        {
            var book = await _bookService.UpdateBookAsunc(id, bookDto);
            return Ok(book);
        }


        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBookAsunc(int id)
        {
            var book = await _bookService.DeleteBookAsunc(id);
            return Ok(book);
        }

    }
}

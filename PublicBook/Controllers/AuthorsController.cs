using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicBook.Service;

namespace PublicBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        readonly private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
           var movie = await _authorService.GetAllAsync();
            return Ok(movie);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
           var author = await _authorService.GetByIdAsync(id);
            return Ok(author);

        }


        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDTO authorDto)
        {
           var author = await _authorService.CreateAsync(authorDto);
            return Ok(author);

        }


        [HttpPut("id")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDTO updateAuthorDTO, int id)
        {
            var author = await _authorService.UpdateAsync(updateAuthorDTO, id);
            return Ok(author);

        }

        [HttpDelete("id")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var author = await _authorService.DeleteAsync(id);
            return Ok(author);

        }
        [HttpGet("myId")]
        public async Task<IActionResult> IsAuthorValid(byte myId)
        {
            var genre = await _authorService.IsAuthorValid(myId);
            return Ok(genre);
        }

    }
}

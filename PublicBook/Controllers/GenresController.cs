using Microsoft.AspNetCore.Mvc;
using PublicBook.Service;

namespace PublicBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        readonly private IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _genreService.GetAllAsync();

            return Ok(genres);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var gerne = await _genreService.GetByIdAsync(id);
            return Ok(gerne);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreDTO genreDTO)
        {
            var genre = await _genreService.CreateAsync(genreDTO);
            return Ok(genre);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreDTO genreDTO, byte id)
        {
            var genre = await  _genreService.UpdateAsync(genreDTO, id);
            return Ok(genre);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> RemoveGenre(byte id)
        {
            var genre = await _genreService.DeleteAsync(id);
            return Ok(genre);
        }

        [HttpGet("myId")]
        public async Task<IActionResult> IsGenreValid(byte myId)
        {
            var genre = await _genreService.IsGenreValid(myId);
            return Ok(genre);
        }



    }
}

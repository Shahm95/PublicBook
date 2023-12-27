
using AutoMapper;
using PublicBook.HandelError;

namespace PublicBook.Service
{
    public class GenreService :IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Genre> GetByIdAsync(byte id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Genre> CreateAsync(GenreDTO genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);           
            await _repository.CreateAsync(genre);
            return genre;
        }
        public async Task<Genre> UpdateAsync(UpdateGenreDTO genreDto, byte id)
        {
            var existingGenre = await _repository.GetByIdAsync(genreDto.Id);

            if (existingGenre == null)
                throw new NotFoundException("Genre not found with the specified ID.");

            var updatedGenre = _mapper.Map(genreDto, existingGenre);
            await _repository.UpdateAsync(updatedGenre, id);
            return updatedGenre;

        }
        public async Task<Genre> DeleteAsync(byte id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> IsGenreValid(byte id)
        {
            return await _repository.IsGenreValid(id);
        }
    }
}

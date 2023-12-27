namespace PublicBook.Service
{
    public interface IGenreService
    {
        Task<Genre> GetByIdAsync(byte id);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> CreateAsync(GenreDTO genreDto);
        Task<Genre> UpdateAsync(UpdateGenreDTO genreDto, byte id);
        Task<Genre> DeleteAsync(byte id);
        Task<bool> IsGenreValid(byte id);
    }
}

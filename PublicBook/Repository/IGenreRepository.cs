namespace PublicBook.Repository
{
    public interface IGenreRepository
    {
        Task<Genre> GetByIdAsync(byte id);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> CreateAsync(Genre genre);
        Task<Genre> UpdateAsync(Genre genre, byte id);
        Task<Genre> DeleteAsync(byte id);
        Task<bool> IsGenreValid(byte id);


    }
}

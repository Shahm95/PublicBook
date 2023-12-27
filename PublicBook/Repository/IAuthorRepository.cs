namespace PublicBook.Repository
{
    public interface IAuthorRepository
    {
        Task<Author> GetByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> CreateAsync(Author author);
        Task<Author> UpdateAsync(Author author, int id);
        Task<Author> DeleteAsync(int id);
        Task<bool> IsAuthorValid(int id);

    }
}

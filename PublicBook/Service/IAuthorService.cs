namespace PublicBook.Service
{
    public interface IAuthorService
    {
        Task<Author> GetByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> CreateAsync(AuthorDTO authorDto);
        Task<Author> UpdateAsync(UpdateAuthorDTO updateAuthorDTO, int id);
        Task<Author> DeleteAsync(int id);
        Task<bool> IsAuthorValid(int id);

    }
}

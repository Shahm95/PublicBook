namespace PublicBook.Repository
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> CreateBookAsunc(Book book);
        Task<Book> UpdateBookAsunc(Book book, int id);
        Task<Book> DeleteBookAsunc(int id);

    }
}

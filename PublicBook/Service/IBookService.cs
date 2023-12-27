namespace PublicBook.Service
{
    public interface IBookService
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> CreateBookAsunc(BookDTO bookDto);
        Task<Book> UpdateBookAsunc(int id, UpdateBookDTO updateBookdto);
        Task<Book> DeleteBookAsunc(int id);
    }
}

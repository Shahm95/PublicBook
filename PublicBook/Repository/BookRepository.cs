using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PublicBook.HandelError;

namespace PublicBook.Repository
{
    public class BookRepository : IBookRepository
    {
        readonly private ApplicationDbContext _context;
       
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
          
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(x => x.Genre).Include(x => x.Author).ToArrayAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.Include(x => x.Genre).Include(x => x.Author).SingleOrDefaultAsync(x => x.Id == id);
            if (book == null)
                throw new NotFoundException("ID NOT FOUND");
            return book;    
        }
        public async Task<Book> CreateBookAsunc(Book book)
        {
            if (book == null)
                throw new NotFoundException("book object is null");
            var myBook = await _context.Books.AddAsync(book);
           await  _context.SaveChangesAsync();

            return myBook.Entity;
        }
        public async Task<Book> UpdateBookAsunc(Book book, int id)
        {
            var booky = await _context.Books.FindAsync(id);
            if (booky == null)
                throw new NotFoundException("ID NOT FOUND");

            var myBook =  _context.Books.Update(booky);
            await _context.SaveChangesAsync();

            return myBook.Entity;
        }
        public async Task<Book> DeleteBookAsunc(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                throw new NotFoundException("ID NOT FOUND");
             _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;

        }



     
    }
}

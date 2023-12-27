using Microsoft.EntityFrameworkCore;
using PublicBook.HandelError;
using PublicBook.Models;

namespace PublicBook.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        readonly private ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Author.OrderBy(x => x.Name).ToArrayAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var author = await _context.Author.FindAsync(id);
            if (author == null)
                throw new NotFoundException("ID NOT FOUND");
            return author;


        }
        public async Task<Author> CreateAsync(Author author)
        {
            if (author == null)
                throw new NotFoundException("author object is null");
            var newAuthor = await _context.Author.AddAsync(author);
           await _context.SaveChangesAsync();
            return newAuthor.Entity;
        }

        public async Task<Author> UpdateAsync(Author author, int id)
        {
            var existingAuthor = await GetByIdAsync(id);
            if (existingAuthor is null)
                throw new NotFoundException("ID NOT FOUND");
             _context.Update(existingAuthor);
            await _context.SaveChangesAsync();

            return existingAuthor;

        }
        public async Task<Author> DeleteAsync(int id)
        {
            var author = _context.Author.Find(id);
            if (author == null)
                throw new NotFoundException("Author not found with the specified ID.");
            _context.Author.Remove(author);
            await _context.SaveChangesAsync();
            return author;

        }

        public async Task<bool> IsAuthorValid(int id)
        {
            var author = await _context.Author.AnyAsync(a => a.Id == id);
            return author;
        }
    }
}

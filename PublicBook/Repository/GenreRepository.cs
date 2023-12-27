
using Microsoft.EntityFrameworkCore;
using PublicBook.HandelError;

namespace PublicBook.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.OrderBy(x => x.Name).ToArrayAsync();
        }

        public async Task<Genre> GetByIdAsync(byte id)
        {
            var genre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);
            if (genre == null)
                throw new NotFoundException("ID NOT FOUND");
            return genre;
        }

        public async Task<Genre> CreateAsync(Genre genre)
        {
            if (genre == null)
                throw new NotFoundException("Genre object is null");

            var myGenre = await _context.Genres.AddAsync(genre);

            await _context.SaveChangesAsync();

            return myGenre.Entity;

        }
        public async Task<Genre> UpdateAsync(Genre genre, byte id)
        {
            var myGenre = await _context.Genres.SingleOrDefaultAsync(x => x.Id == id);
            if (myGenre == null)
                throw new NotFoundException("Genre not found with the specified ID.");
             _context.Genres.Update(myGenre);
            await _context.SaveChangesAsync();
            return myGenre;

        }

        public async Task<Genre> DeleteAsync(byte id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null)
                throw new NotFoundException("Genre not found with the specified ID.");
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return genre;

        }

        public async Task<bool> IsGenreValid(byte id)
        {
            return await _context.Genres.AnyAsync(x => x.Id == id);

        }
    }
}

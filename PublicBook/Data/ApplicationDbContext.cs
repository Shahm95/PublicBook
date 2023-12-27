using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PublicBook.Configuration;
using System.Reflection.Emit;

namespace PublicBook.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new BookTypeEntityConfigration().Configure(builder.Entity<Book>());
            new GenreTypeEntityConfigration().Configure(builder.Entity<Genre>());


        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Author { get; set; }



    }
}

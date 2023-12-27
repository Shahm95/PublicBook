using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PublicBook.Configuration
{
    public class BookTypeEntityConfigration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(400);
            builder.HasOne(x => x.Genre).WithMany().HasForeignKey(x => x.GenreId);
            builder.HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorId);





        }
    }
}

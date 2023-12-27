namespace PublicBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public string Description { get; set; }
        public byte[] Poster { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public byte GenreId { get; set; }   
        public Genre Genre { get; set; }

    }
}

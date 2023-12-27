namespace PublicBook.DTO
{
    public class UpdateBookDTO
    {
        public string? Title { get; set; }
        public int? Year { get; set; }
        public double? Rate { get; set; }
        public string? Description { get; set; }
        public IFormFile? Poster { get; set; }
        public int? AuthorId { get; set; }
        public byte? GenreId { get; set; }
    }
}

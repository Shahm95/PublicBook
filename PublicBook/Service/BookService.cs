using AutoMapper;
using PublicBook.HandelError;

namespace PublicBook.Service
{
    public class BookService : IBookService
    {
        readonly private IBookRepository _repository;
        readonly private IGenreService _genreService;
        readonly private IAuthorService _authorService;
       


        readonly private IMapper _mapper;
        readonly private List<String> _FileExtensionThatIsAllowed = new List<string> { ".jpg", ".png"};
        readonly private long _MaxSizeThatIsAllowed = 5242880L;


        public BookService(IBookRepository repository, IMapper mapper, IGenreService genreService, IAuthorService authorService)
        {
            _repository = repository;
            _mapper = mapper;
            _genreService = genreService;
            _authorService = authorService;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _repository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _repository.GetBookByIdAsync(id);
        }

        public async Task<Book> CreateBookAsunc(BookDTO bookDto)
        {

            if (bookDto == null)
                throw new NotFoundException("ID NOT FOUND");

            if (!_FileExtensionThatIsAllowed.Contains(Path.GetExtension(bookDto.Poster.FileName).ToLower()))
                throw new FileExtensionThatIsAllowed("Not Supprted Extension.");
            if (bookDto.Poster.Length > _MaxSizeThatIsAllowed)
                throw new MaxSizeThatIsAllowed("Max Size.");
            var isValidGenre = await _genreService.IsGenreValid(bookDto.GenreId.Value);
            var isValidAuthor = await _authorService.IsAuthorValid(bookDto.AuthorId.Value);

            if (!isValidGenre)
                throw new AuthorOrGenreNotValid("Genre Id Not Valid");

            if (!isValidAuthor)
                throw new AuthorOrGenreNotValid("Author Id Not Valid");

            var book = _mapper.Map<Book>(bookDto);

            using var dataStram = new MemoryStream();
            await bookDto.Poster.CopyToAsync(dataStram);

            book.Poster = dataStram.ToArray();

            return await _repository.CreateBookAsunc(book);

        }
        public async Task<Book> UpdateBookAsunc(int id, UpdateBookDTO updateBookdto)
        {
            var mybook = await _repository.GetBookByIdAsync(id);

            if (mybook == null)
                throw new NotFoundException("ID NOT FOUND");

           if(updateBookdto.Poster != null)
            {
                if (!_FileExtensionThatIsAllowed.Contains(Path.GetExtension(updateBookdto.Poster.FileName).ToLower()))
                    throw new FileExtensionThatIsAllowed("Not Supprted Extension.");
                if (updateBookdto.Poster.Length > _MaxSizeThatIsAllowed)
                    throw new MaxSizeThatIsAllowed("Max Size.");
            }
            if (updateBookdto.Poster == null)
                throw new PosterIsRequire("Poster Is Require");

            var isValidGenre = await _genreService.IsGenreValid(updateBookdto.GenreId.Value);
            var isValidAuthor = await _authorService.IsAuthorValid(updateBookdto.AuthorId.Value);

            if (!isValidGenre)
                throw new AuthorOrGenreNotValid("Genre Id Not Valid");

            if (!isValidAuthor)
                throw new AuthorOrGenreNotValid("Author Id Not Valid");



            var book = _mapper.Map<Book>(updateBookdto);

           

            using var dataStram = new MemoryStream();
            await updateBookdto.Poster.CopyToAsync(dataStram);

            book.Poster = dataStram.ToArray();

            return await _repository.UpdateBookAsunc(book, id);

        }
        public async Task<Book> DeleteBookAsunc(int id)
        {
            return await _repository.DeleteBookAsunc(id);
        }

       
     
    }
}

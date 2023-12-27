using AutoMapper;

namespace PublicBook.DTO
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<UpdateGenreDTO, Genre>();
            CreateMap<Genre, UpdateGenreDTO>();

            CreateMap<Author, AuthorDTO>(); 
            CreateMap<AuthorDTO, Author>();
            CreateMap<UpdateAuthorDTO, Author>();
            CreateMap<Author, UpdateAuthorDTO>();

            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>().ForMember(src => src.Poster, option => option.Ignore());

            CreateMap<Book, UpdateBookDTO>();
            CreateMap<UpdateBookDTO, Book>().ForMember(src => src.Poster, option => option.Ignore()); ;






        }
    }
}

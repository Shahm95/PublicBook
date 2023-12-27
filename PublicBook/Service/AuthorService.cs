using AutoMapper;
using PublicBook.HandelError;

namespace PublicBook.Service
{
    public class AuthorService : IAuthorService
    {
        readonly private IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Author> CreateAsync(AuthorDTO authorDto)
        {    
            var newAuthor = _mapper.Map<Author>(authorDto);
            await _repository.CreateAsync(newAuthor);
            return newAuthor;
            
        }
 
        public async Task<Author> UpdateAsync(UpdateAuthorDTO updateAuthorDTO, int id)
        {
            var exitingAuthor = await _repository.GetByIdAsync(id);
            if (exitingAuthor == null) 
                throw new NotFoundException("Author not found with the specified ID.");

            var UpdateAuthor = _mapper.Map(updateAuthorDTO, exitingAuthor);
            await _repository.UpdateAsync(UpdateAuthor,id);
            return UpdateAuthor;
        }
        public async Task<Author> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);

        }

        public async Task<bool> IsAuthorValid(int id)
        {
            return await _repository.IsAuthorValid(id);
        }
    }
}

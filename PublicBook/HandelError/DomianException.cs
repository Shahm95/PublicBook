namespace PublicBook.HandelError
{
    public abstract class DomianException : Exception
    {
        public DomianException(string? message) : base(message)
        {
        }
    }
    public class NotFoundException : DomianException
    {
        public NotFoundException(string? message) : base(message)
        {
        }
    }
    public class FileExtensionThatIsAllowed : DomianException
    {
        public FileExtensionThatIsAllowed(string? message) : base(message)
        {
        }
    }
    public class MaxSizeThatIsAllowed : DomianException
    {
        public MaxSizeThatIsAllowed(string? message) : base(message)
        {
        }
    }
    public class PosterIsRequire : DomianException
    {
        public PosterIsRequire(string? message) : base(message)
        {
        }
    }
    public class AuthorOrGenreNotValid : DomianException
    {
        public AuthorOrGenreNotValid(string? message) : base(message)
        {
        }
    }

}

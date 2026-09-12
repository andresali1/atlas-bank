namespace Identity.Application.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException(string msg) : base(msg) { }
    }
}

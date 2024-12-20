
namespace Domain.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException() : base("An Error Ocuured. Please try again.")
    {
        
    }
    public BadRequestException(List<string> messages) : base(messages)
    {
    }

    public BadRequestException(string message) : base(message)
    {
    }
}

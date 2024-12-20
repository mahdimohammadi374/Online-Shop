
namespace Domain.Exceptions;

public class ValidationEntityException : BaseException
{
    public ValidationEntityException() : base("An Error Ocuured. Please try again.")
    {
        
    }
    public ValidationEntityException(List<string> messages) : base(messages)
    {
    }

    public ValidationEntityException(string message) : base(message)
    {
    }
}

namespace Domain.Exceptions;

public class BaseException : Exception
{
    public List<string> Messages { get; set; }

    public BaseException(List<string> messages)
    {
        Messages = messages;
    }
    public BaseException(string message) : base(message)
    {
    }
}

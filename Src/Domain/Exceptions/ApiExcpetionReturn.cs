namespace Domain.Exceptions;

public class ApiExcpetionReturn
{
    public ApiExcpetionReturn(string message)
    {
        Message = message;
        Messages.Add(message);

    }

    public ApiExcpetionReturn(string message, int statusCode)
    {
        Message = message;
        StatusCode = statusCode;
    }
    public ApiExcpetionReturn(List<string> messages, int statusCode)
    {
        Messages = messages;
        StatusCode = statusCode;
    }
    public ApiExcpetionReturn(List<string> messages, int statusCode, string details)
    {
        Messages = messages;
        StatusCode = statusCode;
        Details = details;

    }
    public ApiExcpetionReturn(string message, int statusCode, string details)
    {
        Message = message;
        StatusCode = statusCode;
        Details = details;
        Messages.Add(message);

    }
    public ApiExcpetionReturn(int statusCode, string message, List<string> messages, string detail)
    {
        StatusCode = statusCode;
        Messages = messages;
        Details = detail;
        Message = message;

    }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public string Details { get; set; }
    public List<string> Messages { get; set; }
}

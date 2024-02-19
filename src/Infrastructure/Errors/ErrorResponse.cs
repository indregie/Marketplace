namespace Infrastructure.Errors;

public class ErrorResponse
{
    public string Message { get; set; } = string.Empty;

    public static ErrorResponse Create(string message)
    {
        return new ErrorResponse
        {
            Message = message
        };
    }
}


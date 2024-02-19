namespace Domain.Exceptions;

public class InvalidRateException : Exception
{
    public InvalidRateException() : base("Invalid rate. Rate must be an integer between 1 and 5.") { }
}


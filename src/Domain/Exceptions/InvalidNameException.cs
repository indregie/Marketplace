namespace Domain.Exceptions;

public class InvalidNameException : Exception
{
    public InvalidNameException() : base("Item name is not valid.") { }
}


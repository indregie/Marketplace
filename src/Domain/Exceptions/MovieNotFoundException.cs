namespace Domain.Exceptions;

public class MovieNotFoundException : Exception
{
    public MovieNotFoundException() : base("Movie was not found.") { }
}


namespace Domain.Exceptions;

public class CompletionWriteException : Exception
{
    public CompletionWriteException() : base("Failed to write completion.") { }
}


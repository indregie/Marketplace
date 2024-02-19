namespace Domain.Exceptions;

public class UnpaidOrderException : Exception
{
    public UnpaidOrderException() : base("Payment for this order was not set.") { }
}


namespace Domain.Exceptions;

public class PaymentWriteException : Exception
{
    public PaymentWriteException() : base("Failed to write payment.") { }
}


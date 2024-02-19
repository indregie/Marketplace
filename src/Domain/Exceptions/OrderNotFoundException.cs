namespace Domain.Exceptions;

public class OrderNotFoundException : Exception
{
    public OrderNotFoundException() : base("Order was not found.") { }
}


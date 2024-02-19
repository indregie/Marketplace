namespace Domain.Dtos.Request;

public class InsertOrderRequest
{
    public int ItemId { get; set; } = default;
    public int UserId { get; set; } = default;
}

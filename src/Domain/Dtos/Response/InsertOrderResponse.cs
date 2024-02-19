namespace Domain.Dtos.Response;

public class InsertOrderResponse
{
    public int Id { get; set; } = default;
    public int ItemId { get; set; } = default;
    public int UserId { get; set; } = default;
    public DateTime CreatedAt { get; set; }
}

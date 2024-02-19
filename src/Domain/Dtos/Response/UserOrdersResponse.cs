namespace Domain.Dtos.Response;

public class UserOrdersResponse
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? PaidAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}

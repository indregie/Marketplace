namespace Domain.Dtos.Response;

public class OrderCompletedResponse
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? PaidAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}

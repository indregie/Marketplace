namespace Domain.Entities;

public class OrderEntity
{
    public int Id { get; set; } = default;
    public int ItemId { get; set; } = default;
    public int UserId { get; set; } = default;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? PaidAt { get; set; } = null;
    public DateTime? CompletedAt { get; set; } = null;
}

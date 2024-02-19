namespace Domain.Dtos.Response;

public class GetItemsResponse
{
    public List<InsertItemResponse> Items { get; set; } = new List<InsertItemResponse>();
}

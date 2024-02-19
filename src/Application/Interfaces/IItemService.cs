using Domain.Dtos.Request;
using Domain.Dtos.Response;

namespace Application.Interfaces
{
    public interface IItemService
    {
        Task<GetItemsResponse> Get();
        Task<InsertItemResponse> Get(int id);
        Task<InsertItemResponse> Insert(InsertItemRequest request);
    }
}
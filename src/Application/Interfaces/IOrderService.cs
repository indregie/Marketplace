using Domain.Dtos.Request;
using Domain.Dtos.Response;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task CleanUp(DateTime date);
        Task<OrderPaidResponse> Get(int id);
        Task<IEnumerable<UserOrdersResponse>> GetOrders(int userId);
        Task<InsertOrderResponse> Insert(InsertOrderRequest request);
        Task<OrderCompletedResponse> SetAsCompleted(int id);
        Task<OrderPaidResponse> SetAsPaid(int id);
    }
}
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ItemService _itemService;
    private readonly UserService _userService;
    public OrderService(IOrderRepository orderRepository, ItemService itemService, UserService userService)
    {
        _orderRepository = orderRepository;
        _itemService = itemService;
        _userService = userService;
    }

    public async Task<InsertOrderResponse> Insert(InsertOrderRequest request)
    {
        await _itemService.Get(request.ItemId);
        await _userService.Get(request.UserId);

        OrderEntity order = new OrderEntity()
        {
            ItemId = request.ItemId,
            UserId = request.UserId
        };

        OrderEntity result = await _orderRepository.Insert(order);

        InsertOrderResponse response = new InsertOrderResponse()
        {
            Id = result.Id,
            ItemId = result.ItemId,
            UserId = result.UserId,
            CreatedAt = result.CreatedAt
        };

        return response;
    }

    public async Task<OrderPaidResponse> SetAsPaid(int id)
    {
        await Get(id);

        OrderEntity? result = await _orderRepository.SetAsPaid(id, DateTime.Now)
            ?? throw new PaymentWriteException();

        OrderPaidResponse response = new OrderPaidResponse()
        {
            Id = result.Id,
            ItemId = result.ItemId,
            UserId = result.UserId,
            CreatedAt = result.CreatedAt,
            PaidAt = result.PaidAt
        };

        return response;
    }

    public async Task<OrderCompletedResponse> SetAsCompleted(int id)
    {
        var order = await Get(id);

        _ = order.PaidAt 
            ?? throw new UnpaidOrderException();

        OrderEntity? result = await _orderRepository.SetAsCompleted(id, DateTime.Now)
            ?? throw new CompletionWriteException();

        OrderCompletedResponse response = new OrderCompletedResponse()
        {
            Id = result.Id,
            ItemId = result.ItemId,
            UserId = result.UserId,
            CreatedAt = result.CreatedAt,
            PaidAt = result.PaidAt,
            CompletedAt = result.CompletedAt
        };

        return response;
    }

    public async Task<OrderPaidResponse> Get(int id)
    {
        OrderEntity? order = await _orderRepository.Get(id)
           ?? throw new OrderNotFoundException();

        OrderPaidResponse response = new OrderPaidResponse()
        {
            Id = order.Id,
            ItemId = order.ItemId,
            UserId = order.UserId,
            CreatedAt = order.CreatedAt,
            PaidAt = order.PaidAt
        };

        return response;
    }

    public async Task<IEnumerable<UserOrdersResponse>> GetOrders(int userId)
    {
        await _userService.Get(userId);

        IEnumerable<OrderEntity> result = await _orderRepository.GetOrders(userId);
        IEnumerable<UserOrdersResponse> response = result.Select(orderEntity => new UserOrdersResponse()
        {
            Id = orderEntity.Id,
            ItemId = orderEntity.ItemId,
            CreatedAt = orderEntity.CreatedAt,
            PaidAt = orderEntity.PaidAt,
            CompletedAt = orderEntity.CompletedAt
        });

        return response;
    }

    public async Task CleanUp(DateTime date)
    {
        await _orderRepository.CleanUp(date);
    }
}

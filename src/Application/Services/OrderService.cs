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

    //public async Task<GetItemsResponse> Get()
    //{
    //    IEnumerable<ItemEntity> result = await _itemRepository.Get();

    //    GetItemsResponse response = new GetItemsResponse()
    //    {
    //        Items = result.Select(m => new InsertItemResponse { Id = m.Id, Name = m.Name })
    //        .ToList()
    //    };
    //    return response;
    //}

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

    //public async Task<InsertItemResponse> Get(int id)
    //{
    //    ItemEntity? item = await _itemRepository.Get(id)
    //       ?? throw new ItemNotFoundException();

    //    InsertItemResponse response = new InsertItemResponse()
    //    {
    //        Id = item.Id,
    //        Name = item.Name
    //    };

    //    return response;
    //}
}

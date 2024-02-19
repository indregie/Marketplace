using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services;

public class ItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<GetItemsResponse> Get()
    {
        IEnumerable<ItemEntity> result = await _itemRepository.Get();

        GetItemsResponse response = new GetItemsResponse()
        {
            Items = result.Select(m => new InsertItemResponse { Id = m.Id, Name = m.Name })
            .ToList()
        };
        return response;
    }

    public async Task<InsertItemResponse> Insert(InsertItemRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new InvalidNameException();
        }

        ItemEntity item = new ItemEntity()
        {
            Name = request.Name
        };

        ItemEntity result = await _itemRepository.Insert(item);

        InsertItemResponse response = new InsertItemResponse()
        {
            Id = result.Id,
            Name = result.Name
        };

        return response;
    }

    public async Task<InsertItemResponse> Get(int id)
    {
        ItemEntity? item = await _itemRepository.Get(id)
           ?? throw new ItemNotFoundException();

        InsertItemResponse response = new InsertItemResponse()
        {
            Id = item.Id,
            Name = item.Name
        };

        return response;
    }
}

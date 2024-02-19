using Domain.Entities;

namespace Domain.Interfaces;

public interface IItemRepository
{
    Task<IEnumerable<ItemEntity>> Get();
    Task<ItemEntity> Insert(ItemEntity item);
}
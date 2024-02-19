using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemEntity>> Get();
        Task<ItemEntity> Insert(ItemEntity item);
    }
}
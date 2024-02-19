using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<OrderEntity> Insert(OrderEntity order);
    Task<OrderEntity?> Get(int id);
    Task<OrderEntity> SetAsPaid(int id, DateTime date);
}
﻿using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<OrderEntity> Insert(OrderEntity order);
    Task<OrderEntity?> Get(int id);
    Task<OrderEntity?> SetAsPaid(int id, DateTime date);
    Task<OrderEntity?> SetAsCompleted(int id, DateTime date);
    Task<IEnumerable<OrderEntity>> GetOrders(int userId);
    Task CleanUp(DateTime date);
}
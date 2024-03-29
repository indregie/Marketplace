﻿using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IDbConnection _connection;

    public OrderRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<OrderEntity> Insert(OrderEntity order)
    {
        string sql = @"INSERT INTO orders (item_id, user_id, created_at, paid_at, completed_at) 
                        VALUES (@ItemId, @UserId, @CreatedAt, @PaidAt, @CompletedAt) 
                        RETURNING id as Id, item_id as ItemId, user_id as UserId,
                        created_at as CreatedAt";

        var queryObject = new
        {
            order.ItemId,
            order.UserId,
            order.CreatedAt,
            order.PaidAt,
            order.CompletedAt
        };

        return await _connection.QuerySingleAsync<OrderEntity>(sql, queryObject);
    }

    public async Task<OrderEntity?> Get(int id)
    {
        string sql = @"SELECT id as Id, item_id as ItemId, user_id as UserId, created_at as CreatedAt, paid_at as PaidAt
                        FROM orders WHERE id = @id";

        return await _connection.QuerySingleOrDefaultAsync<OrderEntity>(sql, new { id });
    }

    public async Task<OrderEntity?> SetAsPaid(int id, DateTime date)
    {
        string sql = @"UPDATE orders
                        SET paid_at = @Date
                        WHERE id = @Id AND paid_at IS NULL
                        RETURNING id as Id, item_id as ItemId, user_id as UserId,
                        created_at as CreatedAt, paid_at as PaidAt";

        var queryObject = new
        {
            Id = id,
            Date = date
        };

        return await _connection.QuerySingleOrDefaultAsync<OrderEntity>(sql, queryObject);
    }

    public async Task<OrderEntity?> SetAsCompleted(int id, DateTime date)
    {
        string sql = @"UPDATE orders
                        SET completed_at = @Date
                        WHERE id = @Id AND completed_at IS NULL
                        RETURNING id as Id, item_id as ItemId, user_id as UserId,
                        created_at as CreatedAt, paid_at as PaidAt, completed_at as CompletedAt";

        var queryObject = new
        {
            Id = id,
            Date = date
        };

        return await _connection.QuerySingleOrDefaultAsync<OrderEntity>(sql, queryObject);
    }

    public async Task<IEnumerable<OrderEntity>> GetOrders(int userId)
    {
        string sql = @"SELECT id as Id, item_id as ItemId, created_at as CreatedAt, paid_at as PaidAt, completed_at as CompletedAt
                        FROM orders WHERE user_id = @userId";

        return await _connection.QueryAsync<OrderEntity>(sql, new { userId });
    }

    public async Task CleanUp(DateTime date)
    {
        string sql = @"DELETE FROM orders
                        WHERE paid_at IS NULL 
                        AND created_at < @Date - interval '2 hours'";

        await _connection.ExecuteAsync(sql, new { date });
    }
}


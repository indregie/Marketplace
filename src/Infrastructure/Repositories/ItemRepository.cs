using Dapper;
using Domain.Entities;
using System.Data;

namespace Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly IDbConnection _connection;

    public ItemRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<ItemEntity> Insert(ItemEntity item)
    {
        string sql = @"INSERT INTO items (name) 
                        VALUES (@Name) 
                        RETURNING id as Id, name as Name";

        return await _connection.QuerySingleAsync<ItemEntity>(sql, new { name = item.Name });
    }

    public async Task<IEnumerable<ItemEntity>> Get()
    {
        string sql = @"SELECT id as Id, name as Name FROM items";

        return await _connection.QueryAsync<ItemEntity>(sql);
    }

}


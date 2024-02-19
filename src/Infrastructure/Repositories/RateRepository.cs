using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories;

public class RateRepository : IRateRepository
{
    private readonly IDbConnection _connection;

    public RateRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<RateEntity> Insert(RateEntity rate)
    {
        string sql = @"INSERT INTO rates (movie_id, rate) 
                        VALUES (@MovieId, @Rate)
                        RETURNING id as Id, movie_id as MovieId, rate as Rate";

        var queryObject = new
        {
            rate.MovieId,
            rate.Rate
        };

        return await _connection.QuerySingleAsync<RateEntity>(sql, queryObject);
    }

    public async Task<decimal> CountAverage(int movieId)
    {
        string sql = @"SELECT AVG(rate) 
                        FROM rates 
                        WHERE movie_id = @MovieId"
        ;

        return await _connection.QuerySingleOrDefaultAsync<decimal>(sql, new { MovieId = movieId });
    }

}

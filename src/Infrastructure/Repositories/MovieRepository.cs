using Dapper;
using Domain.Entities;
using System.Data;
using System.Data.Common;

namespace Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly IDbConnection _connection;

    public MovieRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<MovieEntity> Insert(MovieEntity movie)
    {
        string sql = @"INSERT INTO movies (name) 
                        VALUES (@Name) 
                        RETURNING id as Id, name as Name";

        //var queryObject = new
        //{
        //    movie.Name,
        //};

        return await _connection.QuerySingleAsync<MovieEntity>(sql, new { name = movie.Name });
    }

    //Better name Get() if no overloads
    public async Task<IEnumerable<MovieEntity>> GetMovies()
    {
        string sql = @"SELECT id as Id, name as Name FROM movies";

        return await _connection.QueryAsync<MovieEntity>(sql);
    }

    public async Task<MovieEntity?> Get(int id)
    {
        string sql = @"SELECT id as Id, name as Name FROM movies WHERE id = @id";

        return await _connection.QuerySingleOrDefaultAsync<MovieEntity>(sql, new { id });
    }
}


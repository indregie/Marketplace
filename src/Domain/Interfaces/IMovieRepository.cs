using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IMovieRepository
    {
        Task<MovieEntity> Insert(MovieEntity movie);
        Task<IEnumerable<MovieEntity>> GetMovies();
        Task<MovieEntity?> Get(int id);
    }
}
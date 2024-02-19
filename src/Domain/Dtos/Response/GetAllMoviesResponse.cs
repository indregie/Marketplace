namespace Domain.Dtos.Response;

public class GetAllMoviesResponse
{
    public List<InsertMovieResponse> Movies { get; set; } = new List<InsertMovieResponse>();
}

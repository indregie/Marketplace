using Domain.Entities;

namespace Domain.Dtos.Response;

public class GetMovieByIdResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal AverageRating { get; set; }
    public List<CommentEntity> Comments { get; set; }
}

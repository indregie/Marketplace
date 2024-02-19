using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CommentService
{
    private readonly ICommentClient _client;
    public CommentService(ICommentClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<CommentEntity>> GetComments()
    {
        IEnumerable<CommentEntity> comments = await _client.Get();
        return comments;
    }

    public async Task<IEnumerable<CommentEntity>> GetComments(int movieId)
    {
        IEnumerable<CommentEntity> comments = await _client.Get();

        var random = new Random();
        IEnumerable<CommentEntity> movieComments = comments
            .Where(c => c.PostId == movieId)
            .OrderBy(_ => random.Next())
            .Take(5);

        return movieComments;
    }
}

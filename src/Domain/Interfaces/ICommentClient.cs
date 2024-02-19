using Domain.Entities;

namespace Domain.Interfaces;

public interface ICommentClient
{
    Task<IEnumerable<CommentEntity>> Get();
}
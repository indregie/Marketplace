using Domain.Entities;

namespace Infrastructure.Clients
{
    public interface IUserClient
    {
        Task<IEnumerable<UserEntity>> Get();
    }
}
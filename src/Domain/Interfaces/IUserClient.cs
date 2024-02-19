using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserClient
{
    Task<IEnumerable<UserEntity>> Get();
}
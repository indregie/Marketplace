using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserEntity>> Get();
        Task<UserEntity> Get(int id);
    }
}
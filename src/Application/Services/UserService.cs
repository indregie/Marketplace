using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService
{
    private readonly IUserClient _client;
    public UserService(IUserClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<UserEntity>> Get()
    {
        IEnumerable<UserEntity> users = await _client.Get();
        return users;
    }
}

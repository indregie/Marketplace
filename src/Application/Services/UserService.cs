using Domain.Entities;
using Domain.Exceptions;
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

    public async Task<UserEntity> Get(int id)
    {
        IEnumerable<UserEntity> users = await _client.Get();
        UserEntity user = users.SingleOrDefault(x => x.Id == id)
            ?? throw new UserNotFoundException();
        return user;
    }
}

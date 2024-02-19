using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Clients;

public class UserClient : IUserClient
{
    private readonly HttpClient _httpClient;

    public UserClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<UserEntity>> Get()
    {
        string url = "https://jsonplaceholder.typicode.com/users";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<UserEntity>>(content)
                ?? new List<UserEntity>();
        }
        else
        {
            await Console.Out.WriteLineAsync($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            return Enumerable.Empty<UserEntity>();
        }
    }

}
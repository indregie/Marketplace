using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Clients;

public class CommentClient : ICommentClient
{
    private readonly HttpClient _httpClient;

    public CommentClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CommentEntity>> Get()
    {
        string url = "https://jsonplaceholder.typicode.com/comments";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<CommentEntity>>(content)
                ?? new List<CommentEntity>();
        }
        else
        {
            await Console.Out.WriteLineAsync($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            return Enumerable.Empty<CommentEntity>();
        }
    }

}
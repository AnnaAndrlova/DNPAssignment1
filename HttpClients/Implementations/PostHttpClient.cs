using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostHttpClient: IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreateAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/posts",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
    public async Task<IEnumerable<Post>> GetPosts(string? titleContains = null)
    {
        string uri = "/posts";
        if (!string.IsNullOrEmpty(titleContains))
        {
            uri += $"?title={titleContains}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
    public async Task<IEnumerable<Post>> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Posts?postId={id}");
        string content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        IEnumerable<Post> post = JsonSerializer.Deserialize<IEnumerable<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}
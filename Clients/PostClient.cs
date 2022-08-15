using Pokeisland_MicroService.Models;
using Pokeisland_MicroService.Models.PokeModels;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Pokeisland_MicroService.Clients;

public class PostClient
{
    private readonly string apiUrl;
    private readonly HttpClient _client;
    public PostClient(HttpClient client)
    {
        _client = client;
        apiUrl = "post";
    }

    public async Task<Pagination<Post>> getPosts(int pageNum)
    {
        HttpResponseMessage response = await _client.GetAsync(apiUrl + $"/{pageNum}");
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Pagination<Post>>(json) ?? new Pagination<Post>();
        return result;
    }

    public async Task addPost(Post newPost)
    {
        var serializedPost = JsonSerializer.Serialize(newPost);
        StringContent content = new StringContent(serializedPost, UnicodeEncoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync(apiUrl, content);
        response.EnsureSuccessStatusCode();
    }
}
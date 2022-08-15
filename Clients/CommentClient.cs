using Pokeisland_MicroService.Models;
using Pokeisland_MicroService.Models.PokeModels;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;


namespace Pokeisland_MicroService.Clients;

public class CommentClient
{
    private readonly string apiUrl;
    private readonly HttpClient _client;
    public CommentClient(HttpClient client)
    {
        _client = client;
        apiUrl = "comment";
    }

    public async Task<Pagination<Comment>> getPostComments(int postId)
    {
        HttpResponseMessage response = await _client.GetAsync(apiUrl + $"/{postId}");
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Pagination<Comment>>(json) ?? new Pagination<Comment>();
        return result;
    }

    public async Task<Pagination<Comment>> getMoreComments(int postId, int pageNum)
    {
        HttpResponseMessage response = await _client.GetAsync(apiUrl + $"/{postId}&{pageNum}");
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<Pagination<Comment>>(json) ?? new Pagination<Comment>();
        return result;
    }

    public async Task addComment(Comment newComment)
    {
        string serializedComment = JsonSerializer.Serialize(newComment);
        StringContent content = new StringContent(serializedComment, UnicodeEncoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync(apiUrl, content);
    }
}
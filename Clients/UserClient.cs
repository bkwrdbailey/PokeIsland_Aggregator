using Pokeisland_MicroService.Models;
using Pokeisland_MicroService.Models.PokeModels;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Pokeisland_MicroService.Clients;

public class UserClient
{
    private readonly string apiUrl;
    private readonly HttpClient _client;
    public UserClient(HttpClient client)
    {
        _client = client;
        apiUrl = "user";
    }

    public async Task<User> getUser(string username)
    {
        HttpResponseMessage response = await _client.GetAsync(apiUrl + $"/{username}");
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<User>(json) ?? new User();
        return result;
    }

    public async Task<User> getUserById(int userId)
    {
        HttpResponseMessage response = await _client.GetAsync(apiUrl + $"/{userId}");
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<User>(json) ?? new User();
        return result;
    }

    public async Task addUser(User newUser)
    {
        var serializedUser = JsonSerializer.Serialize(newUser);
        StringContent content = new StringContent(serializedUser, UnicodeEncoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync(apiUrl, content);
    }
}
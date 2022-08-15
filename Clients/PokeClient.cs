using Pokeisland_MicroService.Models;
using Pokeisland_MicroService.Models.PokeModels;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Pokeisland_MicroService.Clients;

public class PokeClient
{
    private readonly string apiUrl;
    private readonly HttpClient _client;
    public PokeClient(HttpClient client)
    {
        _client = client;
        apiUrl = "pokemon";
    }

    public async Task<List<Pokemon>> getUserPokemon(int userId)
    {
        HttpResponseMessage response = await _client.GetAsync(apiUrl + $"/{userId}");
        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<Pokemon>>(json) ?? new List<Pokemon>();
        return result;
    }

    public async Task addPokemon(Pokemon newPokemon)
    {
        var serializedPokemon = JsonSerializer.Serialize(newPokemon);
        StringContent content = new StringContent(serializedPokemon, UnicodeEncoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync(apiUrl, content);
        response.EnsureSuccessStatusCode(); // Potentially use for failings in http calls paired with a Try/Catch block
    }
}
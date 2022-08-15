using Pokeisland_MicroService.Models;
using Pokeisland_MicroService.Models.PokeModels;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Pokeisland_MicroService.Clients;

public class PokeAPIClient
{
    private HttpClient _client;
    private readonly string apiUrl;
    public PokeAPIClient(HttpClient httpClient)
    {
        _client = httpClient;
        apiUrl = "https://pokeapi.co/api/v2/";
    }

    public async Task<PokemonSprite> getPokemonSprites(string? pokemonName)
    {
        PokemonSprite sprites = new PokemonSprite();

        // Get Pokemon Sprites
        HttpResponseMessage response = await _client.GetAsync(apiUrl + $"pokemon/{pokemonName}");
        var json = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<object>(json);

        Console.WriteLine(result);

        return sprites;
    }

    public async Task<PokemonMove> getPokemonMoveData(string? pokemonMove)
    {
        PokemonMove moves = new PokemonMove();

        // Get Pokemon Move Data
        HttpResponseMessage response = await _client.GetAsync(apiUrl + $"move/{pokemonMove}");
        var json = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<object>(json);

        Console.WriteLine(result);

        return moves;
    }

    public async Task<List<string>> getPokemonType(string? pokemonName)
    {
        List<string> types = new List<string>();
        
        // Get the type(s) for a pokemon
        HttpResponseMessage response = await _client.GetAsync(apiUrl + $"pokemon/{pokemonName}");
        var json = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<object>(json);

        Console.WriteLine(result);

        return types;
    }
}
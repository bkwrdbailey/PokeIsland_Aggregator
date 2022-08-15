using Pokeisland_MicroService.Models;
using Pokeisland_MicroService.Models.PokeModels;
using Pokeisland_MicroService.Clients;

namespace Pokeisland_MicroService.Services;

public class PokemonService : IPokemonService
{
    private readonly PokeClient _client;
    public PokemonService(PokeClient client)
    {
        _client = client;
    }

    public async Task addPokemon(PokemonUI newPokeUI, int userId)
    {
        Pokemon newPokemon = new Pokemon(userId, newPokeUI.name, newPokeUI.base_experience, newPokeUI.experience_needed, newPokeUI.moves[0].name, newPokeUI.moves[1].name, newPokeUI.moves[2].name, 
        newPokeUI.moves[3].name, newPokeUI.stats.hp, newPokeUI.stats.atk, newPokeUI.stats.spDef, newPokeUI.stats.spAtk, newPokeUI.stats.spd, newPokeUI.current_level, newPokeUI.stats.def);
        
        await _client.addPokemon(newPokemon);
    }
}
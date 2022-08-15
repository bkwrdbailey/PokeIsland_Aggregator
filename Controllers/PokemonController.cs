using Microsoft.AspNetCore.Mvc;
using Pokeisland_MicroService.Models.PokeModels;
using Pokeisland_MicroService.Services;

namespace Pokeisland_MicroService.Controllers;

[ApiController]
public class PokemonController
{
    private readonly IPokemonService _service;
    public PokemonController(IPokemonService service)
    {
        _service = service;
    }

    [HttpPost("pokemon/{userId}")]
    public async Task addPokemon(PokemonUI newPokemon, int userId)
    {
        await _service.addPokemon(newPokemon, userId);
    }
}
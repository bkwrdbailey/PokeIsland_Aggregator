using Pokeisland_MicroService.Models.PokeModels;

namespace Pokeisland_MicroService.Services;

public interface IPokemonService
{
    Task addPokemon(PokemonUI newPokeUI, int userId);
}
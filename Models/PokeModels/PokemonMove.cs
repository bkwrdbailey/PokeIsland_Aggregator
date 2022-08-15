
namespace Pokeisland_MicroService.Models.PokeModels;

public class PokemonMove
{
    public int id { get; set; }
    public string? name { get; set; }
    public int accuracy { get; set; }
    public int power { get; set; }
    public int pp { get; set; }
    public string? type { get; set; }
}
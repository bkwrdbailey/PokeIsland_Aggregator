
namespace Pokeisland_MicroService.Models.PokeModels;

public class PokemonUI
{
    public int id { get; set; }
    public string? name { get; set; }
    public List<string>? type { get; set; }
    public int current_level { get; set; }
    public int base_experience { get; set; }
    public int experience_needed { get; set; }
    public List<PokemonMove>? moves { get; set; }
    public PokemonSprite? sprites { get; set; }
    public PokemonStats? stats { get; set; }
}

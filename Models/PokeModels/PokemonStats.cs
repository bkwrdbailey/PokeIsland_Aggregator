
namespace Pokeisland_MicroService.Models.PokeModels;

public class PokemonStats
{
    public PokemonStats(int hp, int atk, int def, int spDef, int spAtk, int spd)
    {
        this.hp = hp;
        this.atk = atk;
        this.def = def;
        this.spDef = spDef;
        this.spAtk = spAtk;
        this.spd = spd;
    }

    public int hp { get; set; }
    public int atk { get; set; }
    public int def { get; set; }
    public int spDef { get; set; }
    public int spAtk { get; set; }
    public int spd { get; set; }
}

namespace Pokeisland_MicroService.Models;

public class Pokemon
{
    public Pokemon()
    {

    }

    public Pokemon(int userId, string? name, int experience, int neededExperience, string? firstMove, string? secondMove, string? thirdMove, string? fourthMove, int hp, int atk, int spDef, int spAtk, int spd, int current_level, int def)
    {
        this.userId = userId;
        this.name = name;
        this.experience = experience;
        this.neededExperience = neededExperience;
        this.firstMove = firstMove;
        this.secondMove = secondMove;
        this.thirdMove = thirdMove;
        this.fourthMove = fourthMove;
        this.hp = hp;
        this.atk = atk;
        this.spDef = spDef;
        this.spAtk = spAtk;
        this.spd = spd;
        this.current_level = current_level;
        this.def = def;
    }

    public int id { get; set; }
    public int userId { get; set; }
    public string? name { get; set; }
    public int experience { get; set; }
    public int neededExperience { get; set; }
    public string? firstMove { get; set; }
    public string? secondMove { get; set; }
    public string? thirdMove { get; set; }
    public string? fourthMove { get; set; }
    public int hp { get; set; }
    public int atk { get; set; }
    public int spDef { get; set; }
    public int spAtk { get; set; }
    public int spd { get; set; }
    public int current_level { get; set; }
    public int def { get; set; }
}
using Pokeisland_MicroService.Models.PokeModels;

namespace Pokeisland_MicroService.Models;

public class UserUI
{
    // Constructor might cause issue?????
    public UserUI(int id, string? username, string? password, string? email, string? firstname, string? lastname, string? bio)
    {
        this.id = id;
        this.username = username;
        this.password = password;
        this.email = email;
        this.firstname = firstname;
        this.lastname = lastname;
        this.bio = bio;
        this.pokemon = null;
    }

    public int id { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }
    public string? email { get; set; }
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public string? bio { get; set; }
    public List<PokemonUI>? pokemon { get; set; }
}
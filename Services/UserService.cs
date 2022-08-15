using Pokeisland_MicroService.Models;
using Pokeisland_MicroService.Models.PokeModels;
using Pokeisland_MicroService.Clients;

namespace Pokeisland_MicroService.Services;

public class UserService : IUserService
{
    private readonly UserClient _userClient;
    private readonly PokeClient _pokeClient;
    private readonly PokeAPIClient _pokeApiClient;
    public UserService(UserClient userClient, PokeClient pokeClient, PokeAPIClient pokeApiClient)
    {
        _userClient = userClient;
        _pokeClient = pokeClient;
        _pokeApiClient = pokeApiClient;
    }

    public async Task<UserUI> getUserData(string username)
    {
        User DBUser = new User();
        List<Pokemon> userPokemon = new List<Pokemon>();
        List<PokemonUI> userPokeUI = new List<PokemonUI>();

        DBUser = await _userClient.getUser(username);
        UserUI user = new UserUI(DBUser.id, DBUser.username, DBUser.password, DBUser.email, DBUser.firstname, DBUser.lastname, DBUser.bio);
        
        userPokemon = await _pokeClient.getUserPokemon(user.id);

        foreach (Pokemon poke in userPokemon)
        {
            PokemonUI pokeUI = new PokemonUI();
            PokemonStats pokeStats = new PokemonStats(poke.hp, poke.atk, poke.def, poke.spDef, poke.spAtk, poke.spd);

            pokeUI.stats = pokeStats;
            
            pokeUI.moves.Add(await _pokeApiClient.getPokemonMoveData(poke.firstMove));
            pokeUI.moves.Add(await _pokeApiClient.getPokemonMoveData(poke.secondMove));
            pokeUI.moves.Add(await _pokeApiClient.getPokemonMoveData(poke.thirdMove));
            pokeUI.moves.Add(await _pokeApiClient.getPokemonMoveData(poke.fourthMove));
            pokeUI.sprites = await _pokeApiClient.getPokemonSprites(poke.name);
            pokeUI.type = await _pokeApiClient.getPokemonType(poke.name);

            userPokeUI.Add(pokeUI);
        }

        user.pokemon = userPokeUI;

        return user;
    }

    public async Task createUser(User newUser)
    {
        await _userClient.addUser(newUser);
    }
}
using Pokeisland_MicroService.Models;

namespace Pokeisland_MicroService.Services;

public interface IUserService
{
    Task<UserUI> getUserData(string username);
    Task createUser(User newUser);
}
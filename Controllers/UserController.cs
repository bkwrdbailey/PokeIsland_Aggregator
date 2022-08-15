using Microsoft.AspNetCore.Mvc;
using Pokeisland_MicroService.Models;
using Pokeisland_MicroService.Services;

namespace Pokeisland_MicroService.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("user/{username}")]
    public async Task<UserUI> getUser(string username)
    {
        return await _service.getUserData(username);
    }
}
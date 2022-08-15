
namespace Pokeisland_MicroService.Models;

public class CommentUI
{
    public int id { get; set; }
    public UserUI? user { get; set; }
    public string? content { get; set; }
}
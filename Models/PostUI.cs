
namespace Pokeisland_MicroService.Models;

public class PostUI
{
    public int id { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public UserUI? postUser { get; set; }
    public List<Comment>? comments { get; set; }
}

namespace Pokeisland_MicroService.Models;

public class Comment
{
    public int id { get; set; }
    public int userId { get; set; }
    public string? content { get; set; }
    public int postId { get; set; }
}
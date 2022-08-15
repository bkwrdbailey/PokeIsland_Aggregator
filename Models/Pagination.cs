
namespace Pokeisland_MicroService.Models;

public class Pagination<T>
{
    public List<T>? items { get; set; }
    public bool hasNext { get; set; }
    public int totalElements { get; set; }
}
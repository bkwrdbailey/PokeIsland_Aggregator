using Pokeisland_MicroService.Models;

namespace Pokeisland_MicroService.Services;

public interface IPostService
{
    Task<Pagination<PostUI>> getPosts(int pageNum);
    Task<Pagination<CommentUI>> getMoreComments(int postId, int pageNum);
}
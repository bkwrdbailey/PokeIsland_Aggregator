using Microsoft.AspNetCore.Mvc;
using Pokeisland_MicroService.Services;
using Pokeisland_MicroService.Models;

namespace Pokeisland_MicroService.Controllers;

[ApiController]
public class PostController
{
    private readonly IPostService _service;
    public PostController(IPostService service)
    {
        _service = service;
    }

    [HttpGet("post/{pageNum}")]
    public async Task<Pagination<PostUI>> getPosts(int pageNum)
    {
        return await _service.getPosts(pageNum);
    }

    [HttpGet("post/comments/{postId}&{pageNum}")]
    public async Task<Pagination<CommentUI>> getComments(int postId, int pageNum)
    {
        return await _service.getMoreComments(postId, pageNum);
    }
}
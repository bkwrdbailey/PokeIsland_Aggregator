using Pokeisland_MicroService.Models;
using Pokeisland_MicroService.Clients;

namespace Pokeisland_MicroService.Services;

public class PostService : IPostService
{
    private readonly CommentClient _commentClient;
    private readonly PostClient _postClient;
    private readonly UserClient _userClient;
    private readonly PokeClient _pokeClient;
    private readonly PokeAPIClient _pokeApiClient;
    public PostService(CommentClient commentClient, PostClient postClient, UserClient userClient, PokeClient pokeClient, PokeAPIClient pokeAPIClient)
    {
        _commentClient = commentClient;
        _postClient = postClient;
        _userClient = userClient;
        _pokeClient = pokeClient;
        _pokeApiClient = pokeAPIClient;
    }

    public async Task<Pagination<PostUI>> getPosts(int pageNum)
    {
        Pagination<Post> posts = new Pagination<Post>();
        Pagination<PostUI> uiPosts = new Pagination<PostUI>();

        posts = await _postClient.getPosts(pageNum);
        uiPosts.totalElements = posts.totalElements;
        uiPosts.hasNext = posts.hasNext;

        foreach (Post p in posts.items)
        {
            PostUI uiPost = new PostUI();
            Pagination<Comment> comments = new Pagination<Comment>();
            Pagination<CommentUI> commentsUI = new Pagination<CommentUI>();

            comments = await _commentClient.getPostComments(p.id);
            commentsUI.items = await aggregateUserCommentData(comments.items, commentsUI.items);

            uiPosts.items.Add(uiPost);
        }

        return uiPosts;
    }

    public async Task<Pagination<CommentUI>> getMoreComments(int postId, int pageNum)
    {
        Pagination<CommentUI> commentsUI = new Pagination<CommentUI>();
        Pagination<Comment> comments = new Pagination<Comment>();

        comments = await _commentClient.getMoreComments(postId, pageNum);
        commentsUI.items = await aggregateUserCommentData(comments.items, commentsUI.items);

        return commentsUI;
    }

    private async Task<List<CommentUI>> aggregateUserCommentData(List<Comment> comments, List<CommentUI> commentsUI)
    {
        foreach (Comment com in comments)
        {
            User commentUser = new User();
            CommentUI comment = new CommentUI();
            List<Pokemon> userPokemons = new List<Pokemon>();

            commentUser = await _userClient.getUserById(com.userId);
            UserUI userUI = new UserUI(commentUser.id, commentUser.username, commentUser.password, commentUser.email, commentUser.firstname, commentUser.lastname, commentUser.bio);
            userPokemons = await _pokeClient.getUserPokemon(userUI.id); // Make sure proper pokemon is being grabbed
            /* Get proper pokemon data from PokeAPI here */
            comment.user = userUI;
            comment.id = com.id;
            comment.content = com.content;

            commentsUI.Add(comment);
        }

        return commentsUI;
    }
}
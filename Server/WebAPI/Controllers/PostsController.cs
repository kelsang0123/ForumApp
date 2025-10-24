using DTOs;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository postRepo;
        public PostsController(IPostRepository postRepo)
        {
            this.postRepo = postRepo;
        }
        [HttpPost]
        public async Task<IResult> AddPost(
          [FromBody] CreatePostDto request,
          [FromServices] IUserRepository userRepo)
        {
            Post post = new(request.Title, request.Body, request.UserId);
            Post created = await postRepo.AddAsync(post);
            return Results.Created($"/posts/{created.Id}", created);
        }
        [HttpPatch("{id:int}")]
        public async Task<IResult> UpdatePost(
            [FromRoute] int id,
            [FromBody] UpdatePostDto request)
        {
            Post postToUpdate = await postRepo.GetSingleAsync(id);
            postToUpdate.Title = request.Title;
            postToUpdate.Body = request.Body;

            await postRepo.UpdateAsync(postToUpdate);
            return Results.NoContent();
        }
        [HttpGet("{id:int}")]
        public async Task<IResult> GetSinglePost(
             [FromRoute] int Id)
        {
            Post post = await postRepo.GetSingleAsync(Id);
            PostDto dto = new PostDto()
            {
                Title = post.Title,
                Body = post.Body,
                UserId = post.UserId
            };
            return Results.Ok(dto);
        }
     [HttpGet]
     public async Task<IResult>GetPosts(
                [FromQuery]string?title=null,
                [FromQuery]string?body=null,
                [FromQuery]int?userId=null)
        {
            List<PostDto> posts = postRepo.GetMany().Select(u=> new PostDto
            {
                Title = u.Title,
                Body = u.Body,
                UserId = u.UserId
            }).ToList();
            return Results.Ok(posts);
        }
        [HttpPost("{postId:int}/comments")]
        public async Task<IResult> AddComment(
            [FromRoute] int postId,
            [FromBody] CreateCommentDto request,
            [FromServices] ICommentRepository commentRepo
        )
   {
            Comment comment = new(request.Body, request.UserId, postId);
            Comment created = await commentRepo.AddAsync(comment);
            CommentDto resultDto = new CommentDto
            {
                Id = created.Id,
                Body = created.Body,
                UserId = created.UserId,
                PostId = created.PostId
            };
           return Results.Created($"/Comments/{created.Id}",resultDto);
        }
    }
}

using System;
using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class SinglePostView
{
    private readonly IPostRepository postRepository;
    public SinglePostView(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }
    public async void ShowSinglePostView()
    {
        GetSinglePostViewTaskAsync();
    }
    private async Task GetSinglePostViewTaskAsync()
    {
        Console.WriteLine("Enter post id to view: ");
        int? postId = Convert.ToInt32(Console.ReadLine());
        Post post =  await postRepository.GetSingleAsync(Convert.ToInt32(postId));
        if (post != null)
        {
            Console.WriteLine($"Title: {post.Title}, Body: {post.Body} and comment: {post.commentBody} by commentId: {post.commentId}");
        }
        else
        {
            Console.WriteLine($"User {post.UserId} doesnot has created a post!");
        }
    }
}

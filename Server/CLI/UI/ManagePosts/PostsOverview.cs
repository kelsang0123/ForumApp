using System;
using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class PostsOverview
{
    private readonly IPostRepository postRepository;
    public PostsOverview(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }
    public async void ShowPostsOverview()
    {
        GetPostsAsync();
    }
    private async Task GetPostsAsync()
    {
        var posts = postRepository.GetManyAsync();
        if (posts != null)
        {
            foreach (Post post in posts)
            {
                Console.WriteLine($"Post ID: {post.Id} and Title: {post.Title}");
            }
        }
        else
        {
            Console.WriteLine("No post created!");
        }
    }
    
}

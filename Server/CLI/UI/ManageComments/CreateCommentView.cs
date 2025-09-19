using System;
using Entities;
using InMemoryRepository;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class CreateCommentView
{
    private readonly ICommentRepository commentRepository;
    public CreateCommentView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }
    public async void CreateACommentAsync()
    {
     Console.WriteLine("Write a comment: ");
       string? body = Console.ReadLine();
        Console.WriteLine("Enter your user id: ");
        int? userId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the post id that you comment on: ");
        int? postId = Convert.ToInt32(Console.ReadLine());
        await AddACommentAsync(body,Convert.ToInt32(userId),Convert.ToInt32(postId));
    }
    private async Task AddACommentAsync(string body, int userId, int postId)
    {
        Comment comment = new Comment {Body = body, UserId = userId, PostId = postId};
        Comment createdComment = await commentRepository.AddAsync(comment);
        if (createdComment != null)
        {
            Console.WriteLine($"Comment with {createdComment.Id} is successfully written by user with id {createdComment.UserId}!");
        }
        else
        {
            Console.WriteLine("Fail to create a comment!");
        }
    }
}

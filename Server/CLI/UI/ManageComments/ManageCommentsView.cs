using System;
using RepositoryContracts;

namespace CLI.UI.ManageComments;

public class ManageCommentsView
{
    private readonly ICommentRepository commentRepository;
    public ManageCommentsView(ICommentRepository commentRepository)
    {
        this.commentRepository = commentRepository;
    }
    public async void ShowCommentsViewAsync()
    {
        bool? exit = false;
        while(!exit)
        {
            Console.WriteLine("==Manage Comments View==");
            string? choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    CreateCommentView createCommentView = new CreateCommentView(commentRepository);
                    createCommentView.CreateACommentAsync();
                    break;
                default:
                    break;
            }
        }
    }
}

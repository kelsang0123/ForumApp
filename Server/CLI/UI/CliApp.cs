using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using CLI.UI.ManageComments;
using CLI.UI.ManagePosts;
using CLI.UI.ManageUsers;
using Entities;
using InMemoryRepository;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp
{
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;
    private readonly ICommentRepository commentRepository;
    public CliApp(IUserRepository userRepository, IPostRepository postRepository, ICommentRepository commentRepository)
    {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
        this.commentRepository = commentRepository;
    }
    public async Task StartAsync()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Choose 1 to manage users");
            Console.WriteLine("Choose 2 to manage posts");
            Console.WriteLine("Choose 3 to manage comments");
            Console.WriteLine("Choose 4 to exit");
            Console.WriteLine("Enter id:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ManageUsersView manageUsersView = new ManageUsersView(userRepository);
                    manageUsersView.ShowUsersViewAsync();
                    break;
                case "2":
                    ManagePostsView managePostsView = new ManagePostsView(postRepository);
                    managePostsView.ShowPostsViewAsync();
                    break;
                case "3":
                    ManageCommentsView manageCommentsView = new ManageCommentsView(commentRepository);
                    manageCommentsView.ShowCommentsViewAsync();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }  
}
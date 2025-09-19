using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
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
            Console.WriteLine("Choose 1 to create new user.");
            Console.WriteLine("Choose 2 to View all users.");
            Console.WriteLine("Choose 3 to update a user details");
            Console.WriteLine("Choose 4 to delete a user");
            Console.WriteLine("Enter id:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var createUserView = new CreateUserView(userRepository);
                    await createUserView.AddUserAsync();
                    break;
                case "2":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
   
}
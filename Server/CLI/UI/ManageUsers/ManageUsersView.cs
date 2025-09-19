using System;
using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ManageUsersView
{
    private readonly IUserRepository userRepository;
    public ManageUsersView(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public async void ShowUsersViewAsync()
    {
        Boolean exit = false;
        while (!exit)
        {
            Console.WriteLine("Choose 1 to Create New User.");
        Console.WriteLine("Choose 2 to view Users.");
        Console.WriteLine("Choose 3 to delete a user by id.");
        Console.WriteLine("Choose 4 to update a user.");
            Console.WriteLine("Choose 5 to proceed");
        string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateUserView createUserView = new CreateUserView(userRepository);
                    createUserView.CreateNewUserAsync();
                    break;
                case "2":
                    ListUsersView listUsersView = new ListUsersView(userRepository);
                        listUsersView.ShowUsersViewAsync();
                    break;
                case "3":
                    Console.WriteLine("Enter user id to delete: ");
                    int?id = Convert.ToInt32(Console.ReadLine());
                    if (id.Equals("") || id==null)
                    {
                         Console.WriteLine("Please enter user id to delete!");
                    }
                    else
                    {
                          await userRepository.DeleteAsync(Convert.ToInt32(id));
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter user id to update: ");
                     id = Convert.ToInt32(Console.ReadLine());
                    User user = await userRepository.GetSingleAsync(Convert.ToInt32(id));
                    if (user != null)
                    {
                        await userRepository.UpdateAsync(user);
                    }
                    else
                    {
                        Console.WriteLine("user in the list is null!");
                    }
                    break;
                case "5":
                    Console.WriteLine("Enter y to proceed: ");
                    string? confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        continue;
                    }
                    else if (confirmation != "y")
                    {
                        exit = true;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid options!");
                    exit = true;
                    break;
            }
        }
}
}

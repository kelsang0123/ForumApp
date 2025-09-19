using System;
using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class CreateUserView
{
  private IUserRepository userRepository;
  public CreateUserView(IUserRepository userRepository)
  {
    this.userRepository = userRepository;
  }
  public async void CreateNewUserAsync()
    {
    Console.WriteLine("Enter username: ");
    string?name = Console.ReadLine();
    Console.WriteLine("Enter a password: ");
    string?password = Console.ReadLine();
     await AddUserAsync(name, password);     
    }
  private async Task AddUserAsync(string name, string password)
  {
    User user = new User {Username = name, Password = password};
    User created = await userRepository.AddAsync(user);
    if (created != null)
    {
      Console.WriteLine($"User created successfully! ID = {created.Id}, Username = {created.Username}.");
    }
        else
        {
      Console.WriteLine("Fail to create a new user!");
        }
  }
}

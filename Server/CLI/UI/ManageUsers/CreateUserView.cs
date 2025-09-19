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
  
  public async Task AddUserAsync()
  {
    Console.WriteLine("Enter username: ");
    string?name = Console.ReadLine();
    Console.WriteLine("Enter a password: ");
    string?password = Console.ReadLine();
    User user = new User { Username = name, Password = password };
    User created = await userRepository.AddAsync(user);
    if (created != null)
    {
      Console.WriteLine("User created successfully!");
    }
  }
}

using Entities;
using RepositoryContracts;

namespace CLI.UI.ManageUsers
{
    public class ListUsersView
    {
        private readonly IUserRepository userRepository;
      public ListUsersView(IUserRepository userRepository)
      {
        this.userRepository = userRepository;
      }
      public async void ShowUsersViewAsync()
        {
        UsersListAsync();
        }
      private async Task UsersListAsync(){
        var users = userRepository.GetMany();
        if (users != null)
        {
          foreach (User user in users)
          {
            Console.WriteLine($"{user.Username}");
          }
        }
        else
        {
          Console.WriteLine("No users in the list!");
        }
      }
    }
}

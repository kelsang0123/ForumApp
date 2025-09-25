using RepositoryContracts;

namespace CLI.UI.ManageComments
{
    public class ManageCommentsView
    {
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;
        private readonly ICommentRepository commentRepository;
        public ManageCommentsView(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        public async void ShowCommentsViewAsync()
        {
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("==Manage Comments View==");
                Console.WriteLine("Choose 1 to create a comment.");
                Console.WriteLine("Choose 2 to exit.");
                Console.WriteLine("Choose y to main view!");
                string? choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        CreateCommentView createCommentView = new CreateCommentView(commentRepository);
                        createCommentView.CreateACommentAsync();
                        break;
                    case "2":
                        exit=true;
                        break;     
                    case "y":
                        CliApp cliApp = new CliApp(userRepository, postRepository, commentRepository);
                        cliApp.StartAsync();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}

using System;
using RepositoryContracts;

namespace CLI.UI.ManagePosts
{
    public class ManagePostsView
    {
        private readonly IUserRepository userRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IPostRepository postRepository;
        public ManagePostsView(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public async void ShowPostsViewAsync()
        {
            Boolean exit = false;
            while(!exit)
            {
                Console.WriteLine("Choose 1 to create a new post.");
                Console.WriteLine("Choose 2 to view posts overview.");
                Console.WriteLine("Choose 3 to view a single post.");
                // Console.WriteLine("Choose 4 to update existing post.");
                // Console.WriteLine("Choose 5 to delete a post.");
                Console.WriteLine("Choose y to main view.");
                string? choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        CreatePostView createPostView = new CreatePostView(postRepository);
                        createPostView.ShowCreatePostsAsync();
                        break;
                    case "2":
                        PostsOverview postsOverview = new PostsOverview(postRepository);
                        postsOverview.ShowPostsOverview();
                        break;
                    case "3":
                        SinglePostView singlePostView = new SinglePostView(postRepository);
                        singlePostView.ShowSinglePostView();
                        break;
                    case "y":
                        CliApp cliApp = new CliApp(userRepository, postRepository, commentRepository);
                        cliApp.StartAsync();
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            }
        }
    }
}

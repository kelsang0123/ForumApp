using Entities;
using RepositoryContracts;
namespace CLI.UI.ManagePosts
{
    public class CreatePostView
    {
        private readonly IPostRepository postRepository;

        public CreatePostView(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }
        public async void ShowCreatePostsAsync()
        {
            Console.WriteLine("Enter a title: ");
            string? title = Console.ReadLine();
            Console.WriteLine("Enter a body: ");
            string? body = Console.ReadLine();
            Console.WriteLine("Enter a user id");
            int? userId = Convert.ToInt32(Console.ReadLine());
            await AddPostAsync(title, body, Convert.ToInt32(userId));
        }
        private async Task AddPostAsync(string title, string body, int userId)
        {
            Post post = new Post { Title = title, Body = body, UserId = userId };
            Post createdPost = await postRepository.AddAsync(post);
            if (createdPost != null)
            {
                Console.WriteLine($"Post is successfully created!, Title = {title}, Body = {body}, UserId = {userId}");
            }
            else
            {
                Console.WriteLine("Fail to create a post!");
            }
        }
    }
}
using Entities;
using RepositoryContracts;

namespace InMemoryRepository;

public class CommentLikeInMemoryRepository : ICommentLikeRepository
{
    List<CommentLike> commentLikes = new List<CommentLike>();
    
    public Task<CommentLike> AddAsync(CommentLike commentLike)
    {
        commentLike.Id = commentLikes.Any()
            ? commentLikes.Max(c => c.Id) + 1
            : 1;
        commentLikes.Add(commentLike);
        return Task.FromResult(commentLike); 
    }

    public Task UpdateAsync(CommentLike commentLike)
    {
        CommentLike? existingCommentLike = commentLikes.SingleOrDefault(c => c.Id == commentLike.Id); 
        if (existingCommentLike is null) 
        { 
            throw new InvalidOperationException(
                $"CommentLike with ID '{commentLike.Id}' not found"); 
        } 
        commentLikes.Remove(existingCommentLike);
        commentLikes.Add(commentLike); 
        return Task.CompletedTask; 
    }

    public Task DeleteAsync(int id)
    {
        CommentLike? commentLikeToDelete = commentLikes.SingleOrDefault(c => c.Id == id);
        if (commentLikeToDelete is null)
        {
            throw new InvalidOperationException(
                $"CommentLike with ID '{id}' not found");
        }

        commentLikes.Remove(commentLikeToDelete);
        return Task.CompletedTask;
    }

    public Task<CommentLike> GetSingleAsync(int id)
    {
        CommentLike? commentLikeToGet = commentLikes.SingleOrDefault(c => c.Id == id);
        if (commentLikeToGet is null)
        {
            throw new InvalidOperationException( $"CommentLike with ID '{id}' not found");
        }
        return Task.FromResult(commentLikeToGet);
    }

    public IQueryable<CommentLike> GetManyAsync()
    {
        return commentLikes.AsQueryable();
    }
}
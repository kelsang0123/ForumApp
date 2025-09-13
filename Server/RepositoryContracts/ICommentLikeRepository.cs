using Entities;

namespace RepositoryContracts;

public interface ICommentLikeRepository
{
    Task<CommentLike> AddAsync(CommentLike commentLike);
    Task UpdateAsync(CommentLike commentLike);
    Task DeleteAsync(int id);
    Task<CommentLike> GetSingleAsync(int id);
    IQueryable<CommentLike> GetManyAsync();
}
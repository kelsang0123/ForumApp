using Entities;
using RepositoryContracts;

namespace InMemoryRepository;

public class LikeInMemoryRepository : ILikeRepository
{
     List<Like> likes = new List<Like>();
     
    public Task<Like> AddAsync(Like like)
    {
        like.Id = likes.Any()
            ? likes.Max(l => l.Id) + 1
            : 1;
        likes.Add(like);
        return Task.FromResult(like); 
    }

    public Task UpdateAsync(Like like)
    {
        Like? existingLike = likes.SingleOrDefault(l => l.Id == like.Id); 
        if (existingLike is null) 
        { 
            throw new InvalidOperationException(
                $"Like with ID '{like.Id}' not found"); 
        } 
        likes.Remove(existingLike);
        likes.Add(like); 
        return Task.CompletedTask; 
    }

    public Task DeleteAsync(int id)
    {
        Like? likeToRemove = likes.SingleOrDefault(l => l.Id == id);
        if (likeToRemove is null)
        {
            throw new InvalidOperationException( $"Like with ID '{id}' not found");
        } 
        likes.Remove(likeToRemove); 
        return Task.CompletedTask;
    }

    public Task<Like> GetSingleAsync(int id)
    {
        Like? likeToGet = likes.SingleOrDefault(l => l.Id == id);
        if (likeToGet is null)
        {
            throw new InvalidOperationException( $"Like with ID '{id}' not found");
        }

        return Task.FromResult(likeToGet);
    }

    public IQueryable<Like> GetManyAsync()
    {
        return likes.AsQueryable();
    }
}
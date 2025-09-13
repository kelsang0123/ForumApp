using Entities;
using RepositoryContracts;

namespace InMemoryRepository;

public class ModeratorInMemoryRepository : IModeratorRepository
{
    List<Moderator> moderators = new List<Moderator>();
    
    public Task<Moderator> AddAsync(Moderator moderator)
    {
        moderator.Id = moderators.Any()
            ? moderators.Max(m => m.Id) + 1
            : 1;
        moderators.Add(moderator);
        return Task.FromResult(moderator);
    }

    public Task UpdateAsync(Moderator moderator)
    {
        Moderator? existingModerator = moderators.SingleOrDefault(m => m.Id == moderator.Id); 
        if (existingModerator is null) 
        { 
            throw new InvalidOperationException(
                $"Moderator with ID '{moderator.Id}' not found"); 
        } 
        moderators.Remove(existingModerator);
        moderators.Add(moderator); 
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Moderator? moderatorToRemove = moderators.SingleOrDefault(m => m.Id == id); 
        if (moderatorToRemove is null) 
        { 
            throw new InvalidOperationException(
                $"Moderator with ID '{id}' not found"); 
        } 
        moderators.Remove(moderatorToRemove); 
        return Task.CompletedTask;
    }

    public Task<Moderator> GetSingleAsync(int id)
    {
        Moderator? moderatorToGet = moderators.SingleOrDefault(m => m.Id == id);
        if (moderatorToGet is null)
        {
            throw new InvalidOperationException( $"Moderator with ID '{id}' not found");
        }
        return Task.FromResult(moderatorToGet); 
    }

    public IQueryable<Moderator> GetManyAsync()
    {
        return moderators.AsQueryable();
    }
}
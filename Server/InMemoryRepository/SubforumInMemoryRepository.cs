using Entities;
using RepositoryContracts;

namespace InMemoryRepository;

public class SubforumInMemoryRepository : ISubforumRepository
{
    List<Subforum> subforums = new List<Subforum>();
    
    public Task<Subforum> AddAsync(Subforum subforum)
    {
        subforum.Id = subforums.Any()
            ? subforums.Max(s => s.Id) + 1
            : 1;
        subforums.Add(subforum);
        return Task.FromResult(subforum);
    }

    public Task UpdateAsync(Subforum subforum)
    {
        Subforum? existingSubforum = subforums.SingleOrDefault(s => s.Id == subforum.Id); 
        if (existingSubforum is null) 
        { 
            throw new InvalidOperationException(
                $"Subforum with ID '{subforum.Id}' not found"); 
        } 
        subforums.Remove(existingSubforum);
        subforums.Add(subforum); 
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
       Subforum? subforumToRemove = subforums.SingleOrDefault(s => s.Id == id);
        if (subforumToRemove is null)
        {
            throw new InvalidOperationException( $"Subforum with ID '{id}' not found");
        } 
        subforums.Remove(subforumToRemove); 
        return Task.CompletedTask;
    }

    public Task<Subforum> GetSingleAsync(int id)
    {
        Subforum? subforumToGet = subforums.SingleOrDefault(s => s.Id == id);
        if (subforumToGet is null)
        {
            throw new InvalidOperationException( $"Subforum with ID '{id}' not found");
        }

        return Task.FromResult(subforumToGet);
    }

    public IQueryable<Subforum> GetManyAsync()
    {
        return subforums.AsQueryable();
    }
}
using Games.Api.Entities;

namespace Games.Api.Repositories;


public interface IGamesRepository
{
    Task<Game?> GetAsync(int id);
    Task<IEnumerable<Game>> GetAllAsync();
    Task CreateAsync(Game game);
    Task UpdateAsync(Game game);
    Task DeleteAsync(int id);
}
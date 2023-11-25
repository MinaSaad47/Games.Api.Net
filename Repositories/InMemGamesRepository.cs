using Games.Api.Entities;

namespace Games.Api.Repositories;


public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = [];

    public async Task<Game?> GetAsync(int id) => await Task.FromResult(games.Find(x => x.Id == id));

    public async Task<IEnumerable<Game>> GetAllAsync() => await Task.FromResult(games);

    public Task CreateAsync(Game game)
    {
        games.Add(game);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Game game)
    {
        var index = games.FindIndex(x => x.Id == game.Id);
        games[index] = game;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var index = games.FindIndex(x => x.Id == id);
        games.RemoveAt(index);
        return Task.CompletedTask;
    }
}
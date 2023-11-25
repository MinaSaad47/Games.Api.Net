using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Api.Data;
using Games.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Api.Repositories;

public class EntityFrameworkGamesRepository : IGamesRepository
{
    private readonly GameStoreContext context;

    public EntityFrameworkGamesRepository(GameStoreContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(Game game)
    {
        await context.games.AddAsync(game);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await context.games.Where(g => g.Id == id).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await context.games.ToListAsync();
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await context.games.FindAsync(id);
    }

    public async Task UpdateAsync(Game game)
    {
        context.Update(game);
        await context.SaveChangesAsync();
    }
}
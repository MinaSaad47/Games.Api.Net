using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Games.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Api.Data;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Game> games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
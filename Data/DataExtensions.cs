using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Games.Api.Data;

public static class DataExtensions
{
    public static async Task InitializeDBAsync(this IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<GameStoreContext>();
        var task = context?.Database.MigrateAsync();
        if (task != null)
        {
            await task;
        }
    }
}
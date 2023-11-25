using Games.Api.Dtos;
using Games.Api.Entities;
using Games.Api.Repositories;

namespace Games.Api.Endpoints;

public static class GamesEntpoints
{
    public static WebApplication MapGamesEndpoints(this WebApplication routes)
    {
        var groups = routes.MapGroup("/games").WithParameterValidation();
        groups.MapGet("/", async (IGamesRepository repository) =>
        {
            return Results.Ok(await repository.GetAllAsync());
        });


        groups.MapGet("/{id}", async (IGamesRepository repository, int id) =>
        {
            var game = await repository.GetAsync(id);
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        });


        groups.MapPost("/", async (IGamesRepository repository, CreateGameDto createGame) =>
        {
            var game = new Game
            {
                Name = createGame.Name,
                Genre = createGame.Genre,
                Price = createGame.Price,
                ImageUri = createGame.ImageUri,
                ReleaseDate = createGame.ReleaseDate,

            };
            await repository.CreateAsync(game);
            return Results.Created($"/games/{game.Id}", game);
        });

        groups.MapDelete("/{id}", async (IGamesRepository repository, int id) =>
        {
            await repository.DeleteAsync(id);
            return Results.Ok();
        })

        ;

        groups.MapPut("/{id}", async (IGamesRepository repository, int id, UpdateGameDto updateGame) =>
        {
            Game? game = await repository.GetAsync(id);

            if (game is null)
            {
                return Results.NotFound();
            }

            game.Name = updateGame.Name;
            game.Genre = updateGame.Genre;
            game.Price = updateGame.Price;
            game.ImageUri = updateGame.ImageUri;
            game.ReleaseDate = updateGame.ReleaseDate;

            await repository.UpdateAsync(game);

            return Results.Ok();
        });

        return routes;
    }
}
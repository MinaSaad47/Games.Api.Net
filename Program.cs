using Games.Api.Entities;
using Games.Api.Repositories;
using Games.Api.Endpoints;
using Games.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();

var connString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddDbContext<GameStoreContext>(options => options.UseSqlServer(connString));

var app = builder.Build();

await app.Services.InitializeDBAsync();

app.MapGamesEndpoints();

app.Run();

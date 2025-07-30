using gamestore.Data;
using gamestore.dtos;
using gamestore.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();


app.MapGamesEndpoints();

app.MigrateDb();

app.Run();

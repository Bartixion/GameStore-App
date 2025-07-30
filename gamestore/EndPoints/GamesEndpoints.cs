using gamestore.dtos;

namespace gamestore.EndPoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static List<GameDto> games = [
        new(
            1,
            "street fighter II",
            "street fighting",
            19.99M,
            new DateOnly(1992 , 7, 15)
        ),
        new(
            2,
            "Fifa 23",
            "sport",
            12.99M,
            new DateOnly(2022 , 7, 15)
        ),
        new(
            3,
            "Grand theft auto V",
            "sandobx",
            49.99M,
            new DateOnly(2009 , 6, 13)
        )
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        //GET /games
        group.MapGet("/", () => games);

        //GET /games/1
        group.MapGet("/{id}", (int id) =>
        {
            GameDto game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);

        }).WithName(GetGameEndpointName);

        //POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
            {

                
                GameDto game = new(
                    games.Count + 1,
                    newGame.Name,
                    newGame.Genere,
                    newGame.Price,
                    newGame.ReleaseDate
                );
                games.Add(game);

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            });

        //PUT /games
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
            {
                var index = games.FindIndex(game => game.Id == id);

                if (index == -1)
                {
                    return Results.NotFound();
                }

                games[index] = new GameDto(
                    id,
                    updatedGame.Name,
                    updatedGame.Genere,
                    updatedGame.Price,
                    updatedGame.ReleaseDate
                );

                return Results.NoContent();
            });

        //DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent;
        });

        return group;
    }
}

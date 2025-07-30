using System;

namespace gamestore.Entities;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int GenereId { get; set; }
    public Genere? Genere { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

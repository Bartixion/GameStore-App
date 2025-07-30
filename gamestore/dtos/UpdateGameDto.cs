using System.ComponentModel.DataAnnotations;
namespace gamestore.dtos;

public record class UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)]string Genere,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate)
{

}

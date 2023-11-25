using System.ComponentModel.DataAnnotations;

namespace Games.Api.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);


public record CreateGameDto(
    [Required][MaxLength(50)] string Name,
    [Required][StringLength(50)] string Genre,
    [Required][Range(0, 100)] decimal Price,
    [Required] DateTime ReleaseDate,
    [Required][Url][StringLength(100)] string ImageUri
);

public record UpdateGameDto(
    [Required][MaxLength(50)] string Name,
    [Required][StringLength(50)] string Genre,
    [Required][Range(0, 100)] decimal Price,
    [Required] DateTime ReleaseDate,
    [Required][Url][StringLength(100)] string ImageUri
);
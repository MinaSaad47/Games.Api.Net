using System.ComponentModel.DataAnnotations;

namespace Games.Api.Entities;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [Required]
    [StringLength(20)]
    public required string Genre { get; set; }
    [Required]
    [Url]
    [StringLength(100)]
    public required string ImageUri { get; set; }
    [Required]
    [Range(0, 100)]
    public required decimal Price { get; set; }
    [Required]
    public required DateTime ReleaseDate { get; set; }
}
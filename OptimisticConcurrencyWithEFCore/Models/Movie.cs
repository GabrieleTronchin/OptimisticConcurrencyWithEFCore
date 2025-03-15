using System.ComponentModel.DataAnnotations;

namespace OptimisticConcurrency.Host.Models;

public class CreateMovie
{
    public string Title { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
}


public class Movie : CreateMovie
{
    [Required]
    public int Id { get; set; }

    [Required]
    public byte[] RowVersion { get; set; }
}

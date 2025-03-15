using System.ComponentModel.DataAnnotations;

namespace OptimisticConcurrency.Persistence.Entities;

public class MovieEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace OptimisticConcurrency.Persistence.Entities;

public class MovieEntity
{
    [Key]
    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string ImdbId { get; private set; } = string.Empty;
    public string Stars { get; private set; } = string.Empty;
    public DateTime ReleaseDate { get; private set; }

    /// <summary>
    /// Only SQL Server
    /// </summary>
    [Timestamp]
    public byte[] RowVersion { get; set; }
}
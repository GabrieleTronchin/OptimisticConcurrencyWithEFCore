using Microsoft.EntityFrameworkCore;
using OptimisticConcurrency.Persistence.Entities;

namespace OptimisticConcurrency.Persistence;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options) { }

    public DbSet<MovieEntity> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaDbContext).Assembly);
    }
}

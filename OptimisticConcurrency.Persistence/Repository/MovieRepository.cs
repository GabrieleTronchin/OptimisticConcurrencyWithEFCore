using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OptimisticConcurrency.Persistence.Entities;

namespace OptimisticConcurrency.Persistence.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly CinemaDbContext _context;
    private readonly ILogger<MovieRepository> _logger;

    public MovieRepository(ILogger<MovieRepository> logger, CinemaDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public DbSet<MovieEntity> Entity
    {
        get => _context.Movies;
    }

    public async Task<MovieEntity> GetAsync(int id, CancellationToken cancel)
    {
        return await _context.Movies.SingleOrDefaultAsync(x => x.Id == id, cancel)
            ?? throw new InvalidOperationException(
                $"System could not find any {nameof(MovieEntity.Id)} with value {id}"
            );
    }

    public async Task<IEnumerable<MovieEntity>> GetAsync(CancellationToken cancel)
    {
        return await _context.Movies.ToListAsync(cancel);
    }

    public async Task<IEnumerable<MovieEntity>> GetAsync(
        Expression<Func<MovieEntity, bool>> filter,
        CancellationToken cancel
    )
    {
        return await _context.Movies.Where(filter).ToListAsync(cancel);
    }

    public async Task AddAsync(MovieEntity entity)
    {
        await _context.AddAsync(entity);
    }

    public void Update(MovieEntity entity)
    {
        _context.Update(entity);
    }

    public void Remove(MovieEntity entity)
    {
        _context.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, "Concurrency exception occurred while saving changes.");
            throw new InvalidOperationException("A concurrency conflict occurred while saving changes. Please try again.", ex);
        }
    }
}

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OptimisticConcurrency.Persistence.Entities;

namespace OptimisticConcurrency.Persistence.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly CinemaDbContext _context;

    public MovieRepository(CinemaDbContext context)
    {
        _context = context;
    }

    public DbSet<MovieEntity> Entity { get => _context.Movies; }

    public async Task<MovieEntity> GetAsync(int id, CancellationToken cancel)
    {
        return await _context.Movies
            .SingleOrDefaultAsync(x => x.Id == id, cancel) ??
             throw new InvalidOperationException($"System could not find any {nameof(MovieEntity.Id)} with value {id}");
    }

    public async Task<IEnumerable<MovieEntity>> GetAsync(CancellationToken cancel)
    {
        return await _context.Movies
        .ToListAsync(cancel);

    }

    public async Task<IEnumerable<MovieEntity>> GetAsync(Expression<Func<MovieEntity, bool>> filter, CancellationToken cancel)
    {

        return await _context.Movies
            .Where(filter)
            .ToListAsync(cancel);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
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

}

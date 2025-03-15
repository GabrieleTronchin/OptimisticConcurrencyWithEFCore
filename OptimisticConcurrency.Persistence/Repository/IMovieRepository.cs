using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OptimisticConcurrency.Persistence.Entities;

namespace OptimisticConcurrency.Persistence.Repository
{
    public interface IMovieRepository
    {
        DbSet<MovieEntity> Entity { get; }
        Task AddAsync(MovieEntity entity);
        Task<IEnumerable<MovieEntity>> GetAsync(CancellationToken cancel);
        Task<IEnumerable<MovieEntity>> GetAsync(
            Expression<Func<MovieEntity, bool>> filter,
            CancellationToken cancel
        );
        Task<MovieEntity> GetAsync(int id, CancellationToken cancel);
        void Remove(MovieEntity entity);
        Task SaveChangesAsync();
        void Update(MovieEntity entity);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OptimisticConcurrency.Persistence.Repository;

namespace OptimisticConcurrency.Persistence;

public static class ServicesExtensions
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddDbContext<CinemaDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}

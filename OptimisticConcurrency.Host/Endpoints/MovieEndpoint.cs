using Microsoft.AspNetCore.Mvc;
using OptimisticConcurrency.Host.Models;
using OptimisticConcurrency.Persistence.Repository;

namespace OptimisticConcurrency.Host.Endpoints;

public static class MovieEndpoint
{
    public static void AddEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/movies",
            async (IMovieRepository repository, CancellationToken cancellationToken) =>
            {
                return await repository.GetAsync(cancellationToken);
            }
        );

        app.MapGet(
            "/movie/{id}",
            async (int id, IMovieRepository repository, CancellationToken cancellationToken) =>
            {
                return await repository.GetAsync(id, cancellationToken);
            }
        );

        app.MapPost(
            "/movie",
            async (
                [FromBody] CreateMovie payload,
                [FromServices] IMovieRepository repository,
                CancellationToken cancellationToken
            ) =>
            {
                await repository.AddAsync(
                    new Persistence.Entities.MovieEntity()
                    {
                        Title = payload.Title,
                        ReleaseDate = payload.ReleaseDate,
                    }
                );

                await repository.SaveChangesAsync();
            }
        );

        app.MapPut(
            "/movie",
            async (
                [FromBody] Movie payload,
                [FromServices] IMovieRepository repository,
                CancellationToken cancellationToken
            ) =>
            {
                repository.Update(
                    new Persistence.Entities.MovieEntity()
                    {
                        Id = payload.Id,
                        Title = payload.Title,
                        ReleaseDate = payload.ReleaseDate,
                        RowVersion = payload.RowVersion,
                    }
                );

                await repository.SaveChangesAsync();
            }
        );
    }
}

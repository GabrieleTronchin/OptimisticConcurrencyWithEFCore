using OptimisticConcurrency.Persistence.Repository;

namespace OptimisticConcurrency.Host.Endpoints;

public static class MovieEndpoint
{
    public static void AddEndpoints(this IEndpointRouteBuilder app)
    {

        app.MapGet("/Movies", async (IMovieRepository repository, CancellationToken cancellationToken) =>
        {
            return await repository.GetAsync(cancellationToken);
        });
    }
}


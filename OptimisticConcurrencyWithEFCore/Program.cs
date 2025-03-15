using OptimisticConcurrency.Host.Endpoints;
using OptimisticConcurrency.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var routeBuilder = app.MapGroup("/v1/cinema");
routeBuilder.AddEndpoints();

app.Run();

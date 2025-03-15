using OptimisticConcurrency.Host.Endpoints;
using OptimisticConcurrency.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var routeBuilder = app.MapGroup("/v1/cinema");
routeBuilder.AddEndpoints();

app.Run();

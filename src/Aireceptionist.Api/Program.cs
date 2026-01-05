using Aireceptionist.Application.Common;
using Aireceptionist.Application.Contracts;
using Aireceptionist.Application.Interfaces;
using Aireceptionist.Application.Services;
using Aireceptionist.Infrastructure.Persistence;
using Aireceptionist.Infrastructure.Time;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IReceptionRequestService, ReceptionRequestService>();
builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddSingleton<IReceptionRequestRepository, InMemoryReceptionRequestRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapPost("/reception/requests", async (
    CreateReceptionRequestRequest request,
    IReceptionRequestService service,
    CancellationToken cancellationToken) =>
{
    var response = await service.CreateAsync(request, cancellationToken);
    return Results.Created($"/reception/requests/{response.Id}", response);
});

app.Run();

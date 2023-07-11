using Contracts;
using FastEndpoints;

var bld = WebApplication.CreateBuilder();
bld.Logging.ClearProviders();
bld.WebHost.ConfigureKestrel(o => o.ListenLocalhost(5000));
var app = bld.Build();

app.MapRemote("http://localhost:6000", c =>
{
    c.RegisterEvent<HelloWorldEvent>();
});

app.MapGet("/", () =>
{
    Parallel.ForEach(Enumerable.Range(1, 100000), async i =>
    {
        await new HelloWorldEvent
        {
            Id = i,
        }
        .RemotePublishAsync();
    });

    return Results.Ok("all events sent to broker!");
});

app.Run();

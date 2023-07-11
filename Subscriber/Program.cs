using Contracts;
using FastEndpoints;
using Subscriber;

var bld = WebApplication.CreateBuilder();
bld.Logging.ClearProviders();
bld.WebHost.ConfigureKestrel(o => o.ListenLocalhost(7000));
var app = bld.Build();

app.MapRemote("http://localhost:6000", c =>
{
    c.Subscribe<HelloWorldEvent, HelloWorldHandler>();
});

app.Run();

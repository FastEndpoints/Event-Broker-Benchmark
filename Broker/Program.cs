using Contracts;
using FastEndpoints;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var bld = WebApplication.CreateBuilder();
bld.Logging.ClearProviders();
bld.WebHost.ConfigureKestrel(o => o.ListenLocalhost(6000, o => o.Protocols = HttpProtocols.Http2));
bld.AddHandlerServer();

var app = bld.Build();
app.MapHandlers(h =>
{
    h.RegisterEventHub<HelloWorldEvent>(HubMode.EventBroker);
});

app.Run();
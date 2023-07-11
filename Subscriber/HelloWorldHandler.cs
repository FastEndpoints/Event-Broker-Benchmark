using Contracts;
using FastEndpoints;
using System.Diagnostics;

namespace Subscriber;

internal class HelloWorldHandler : IEventHandler<HelloWorldEvent>
{
    private static int Count;
    private static readonly Stopwatch sw = new();

    public Task HandleAsync(HelloWorldEvent evnt, CancellationToken ct)
    {
        if (Count == 1)
            sw.Start();

        Count++;

        if (Count == HelloWorldEvent.TotalEventCount)
        {
            var secs = sw.Elapsed.TotalSeconds;
            Console.WriteLine($"Total Event Count: {HelloWorldEvent.TotalEventCount}");
            Console.WriteLine($"Total Time Taken: {secs:0.00} seconds");
            Console.WriteLine($"Events Per Second: {HelloWorldEvent.TotalEventCount / secs:0}");
        }

        return Task.CompletedTask;
    }
}
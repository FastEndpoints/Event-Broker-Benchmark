using FastEndpoints;

namespace Contracts;

public sealed class HelloWorldEvent : IEvent
{
    public const int TotalEventCount = 100000;

    public int Id { get; set; }
    public string Message { get; } = "Hello World!";
}
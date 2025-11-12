namespace Xulolo.Terminal.Events
{
    internal interface IEventSource
    {
        Task RunAsync(CancellationToken cancellationToken);
    }
}

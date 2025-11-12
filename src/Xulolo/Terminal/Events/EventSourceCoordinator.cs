namespace Xulolo.Terminal.Events
{
    internal class EventSourceCoordinator : IAsyncDisposable
    {
        private readonly Task _task;

        public EventSourceCoordinator(CancellationToken ct, params IEventSource[] eventSources)
        {
            _task = Task.WhenAll(eventSources.Select(s => s.RunAsync(ct)).ToList());
        }

        public async ValueTask DisposeAsync()
        {
            await _task;
        }
    }
}

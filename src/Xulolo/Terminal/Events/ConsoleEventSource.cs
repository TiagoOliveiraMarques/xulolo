namespace Xulolo.Terminal.Events
{
    internal sealed class ConsoleEventSource(EventOutbox outbox) : IEventSource
    {
        public async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                while (!Console.KeyAvailable)
                    await Task.Delay(50, cancellationToken);

                var keyInfo = Console.ReadKey(true);
                var @event = new TerminalKeyEvent(keyInfo.Key);

                await outbox.SendAsync(@event, cancellationToken);
            }
        }
    }
}

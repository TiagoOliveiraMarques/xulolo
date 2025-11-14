using System.Threading.Channels;

namespace Xulolo.Events
{
    public sealed class ConsoleEventSource : IEventSource
    {
        private readonly Channel<Event> _outbox;
        private readonly Task _backgroundTask;
        private readonly CancellationTokenSource _cts;

        public ConsoleEventSource(int outboxCapacity)
        {
            _outbox = Channel.CreateBounded<Event>(outboxCapacity);
            _cts = new CancellationTokenSource();
            _backgroundTask = Task.Run(async () => await EventLoopAsync(_cts.Token));
        }

        public ChannelReader<Event> ChannelReader => _outbox.Reader;

        public async ValueTask DisposeAsync()
        {
            _cts.Cancel();
            await _backgroundTask;
        }

        private async Task EventLoopAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                var consoleKey = Console.ReadKey(true);
                var @event = new KeyPressEvent(consoleKey.Key, consoleKey.KeyChar);

                await _outbox.Writer.WriteAsync(@event, ct);
            }
        }
    }
}

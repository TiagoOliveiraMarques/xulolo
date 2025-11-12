using System.Threading.Channels;

namespace Xulolo.Terminal.Events
{
    public class EventOutbox
    {
        private readonly Channel<TerminalEvent> _outbox;
        
        public EventOutbox(int capacity)
        {
            _outbox = Channel.CreateBounded<TerminalEvent>(capacity);
        }

        public ValueTask SendAsync(TerminalEvent terminalEvent, CancellationToken cancellationToken = default)
        {
            return _outbox.Writer.WriteAsync(terminalEvent, cancellationToken);
        }

        public ValueTask<TerminalEvent> ReceiveAsync(CancellationToken cancellationToken)
        {
            return _outbox.Reader.ReadAsync(cancellationToken);
        }
    }
}

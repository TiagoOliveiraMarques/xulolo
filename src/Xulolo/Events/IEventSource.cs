using System.Threading.Channels;

namespace Xulolo.Events
{
    public interface IEventSource : IAsyncDisposable
    {
        ChannelReader<Event> ChannelReader { get; }
    }
}

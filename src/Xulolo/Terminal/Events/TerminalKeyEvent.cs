namespace Xulolo.Terminal.Events
{
    public sealed class TerminalKeyEvent(ConsoleKey key) : TerminalEvent
    {
        public ConsoleKey Key { get; } = key;
    }
}

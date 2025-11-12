namespace Xulolo.Terminal.Events
{
    public sealed class TerminalKeyEvent(ConsoleKey key, char keyChar) : TerminalEvent
    {
        public ConsoleKey Key { get; } = key;
        public char KeyChar { get; } = keyChar;
    }
}

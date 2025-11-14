namespace Xulolo.Events
{
    public class KeyPressEvent : Event
    {
        public KeyPressEvent(ConsoleKey key, char keyChar)
        {
            Key = key;
            KeyChar = keyChar;
        }

        public ConsoleKey Key { get; }
        public char KeyChar { get; }
    }
}

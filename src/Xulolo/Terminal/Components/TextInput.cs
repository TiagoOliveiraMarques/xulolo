using Xulolo.Terminal.Events;
using Xulolo.Terminal.Renderer;

namespace Xulolo.Terminal.Components
{
    internal class TextInput : IComponent
    {
        public string Text { get; private set; }
        public bool Focused { get; set; } 

        public void Render(IRenderer renderer)
        {
            renderer.Render("\u270E");
            renderer.Render(" ");
            renderer.Render(Text);
            renderer.Render("\n");
        }

        public void Update(TerminalEvent @event)
        {
            if (!Focused) return;

            if (@event is TerminalKeyEvent keyEvent)
            {
                if (keyEvent.Key == ConsoleKey.Backspace)
                {
                    if (Text.Length > 0)
                    {
                        Text = Text[..^1];
                    }
                }
                else if (keyEvent.Key == ConsoleKey.Enter)
                {
                    // Do nothing on Enter
                }
                else
                {
                    var keyChar = keyEvent.KeyChar;
                    if (!char.IsControl(keyChar))
                    {
                        Text += keyChar;
                    }
                }
            }
        }
    }
}

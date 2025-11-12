using Xulolo.Terminal.Events;
using Xulolo.Terminal.Renderer;

namespace Xulolo.Terminal.Components
{
    public class Checkbox : IComponent
    {
        public Checkbox(string text)
        {
            Text = text;
            Checked = false;
            Focused = false;
        }

        public string Text { get; private set; }
        public bool Checked { get; set; }
        public bool Focused { get; set; }

        private ReadOnlySpan<char> Prefix => Checked ? "\u2705" : "\U0001F532";

        public void Render(IRenderer renderer)
        {
            renderer.Render(Prefix);
            renderer.Render(" ");
            renderer.Render(Text);
            renderer.Render("\n");
        }

        public void Update(TerminalEvent @event)
        {
            if (!Focused) return;
            if (@event is TerminalKeyEvent keyEvent && keyEvent.Key == ConsoleKey.Enter)
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            Checked = !Checked;
        }
    }
}

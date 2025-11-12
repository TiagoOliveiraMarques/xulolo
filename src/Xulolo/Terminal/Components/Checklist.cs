using Xulolo.Terminal.Events;
using Xulolo.Terminal.Renderer;

namespace Xulolo.Terminal.Components
{
    public class Checklist : IComponent
    {
        private readonly List<Checkbox> _checkboxes = new();
        private int _focusedIndex = 0;

        public Checklist(params Checkbox[] checkboxes)
        {
            _checkboxes.AddRange(checkboxes);
            if (_checkboxes.Count > 0)
            {
                _checkboxes[0].Focused = true;
                _focusedIndex = 0;
            }
        }

        public void Render(IRenderer renderer)
        {
            foreach (var checkbox in _checkboxes)
            {
                var cursor = checkbox.Focused ? " \u276F " : "   ";
                renderer.Render(cursor);
                checkbox.Render(renderer);
            }
        }

        public void Update(TerminalEvent @event)
        {
            if (@event is TerminalKeyEvent keyEvent)
            {
                switch (keyEvent.Key)
                {
                    case ConsoleKey.UpArrow:
                        _focusedIndex = Math.Clamp(_focusedIndex - 1, 0, _checkboxes.Count - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        _focusedIndex = Math.Clamp(_focusedIndex + 1, 0, _checkboxes.Count - 1);
                        break;
                }

                _checkboxes.ForEach(c => c.Focused = false);
                _checkboxes[_focusedIndex].Focused = true;
            }

            foreach (var checkbox in _checkboxes)
            {
                checkbox.Update(@event);
            }
        }
    }
}

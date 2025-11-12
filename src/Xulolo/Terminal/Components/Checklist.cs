using Xulolo.Terminal.Events;
using Xulolo.Terminal.Renderer;

namespace Xulolo.Terminal.Components
{
    public class Checklist : IComponent
    {
        private readonly List<IComponent> _components = new();
        private int _focusedIndex = 0;

        public Checklist(params IComponent[] components)
        {
            _components.AddRange(components);
            BlurAll();
            
            if (_components.Count > 0)
            {
                _components[0].Focused = true;
                _focusedIndex = 0;
            }
        }

        public bool Focused { get; set; } = true;

        public void Render(IRenderer renderer)
        {
            foreach (var component in _components)
            {
                var cursor = component.Focused ? " \u276F " : "   ";
                renderer.Render(cursor);
                component.Render(renderer);
            }
        }

        public void Update(TerminalEvent @event)
        {
            if (!Focused) return;

            if (@event is TerminalKeyEvent keyEvent)
            {
                switch (keyEvent.Key)
                {
                    case ConsoleKey.UpArrow:
                        _focusedIndex = Math.Clamp(_focusedIndex - 1, 0, _components.Count - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        _focusedIndex = Math.Clamp(_focusedIndex + 1, 0, _components.Count - 1);
                        break;
                }

                BlurAll();
                _components[_focusedIndex].Focused = true;
            }

            foreach (var component in _components)
            {
                component.Update(@event);
            }
        }

        private void BlurAll()
        {
            foreach (var component in _components)
            {
                component.Focused = false;
            }
        }
    }
}

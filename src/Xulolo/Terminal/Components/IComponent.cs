using Xulolo.Terminal.Events;
using Xulolo.Terminal.Renderer;

namespace Xulolo.Terminal.Components
{
    public interface IComponent
    {
        bool Focused { get; set; }

        void Update(TerminalEvent @event);

        void Render(IRenderer renderer);
    }
}

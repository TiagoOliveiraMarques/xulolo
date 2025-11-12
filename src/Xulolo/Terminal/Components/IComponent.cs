using Xulolo.Terminal.Events;
using Xulolo.Terminal.Renderer;

namespace Xulolo.Terminal.Components
{
    public interface IComponent
    {
        void Update(TerminalEvent @event);

        void Render(IRenderer renderer);
    }
}

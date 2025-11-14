using Xulolo.Renderer;

namespace Xulolo.View
{
    /// <summary>
    /// Layout view component that arranges other components stacked 
    /// vertically.
    /// </summary>
    public sealed class Block : IView
    {
        public Block(params IView[] children)
        {
            Children = children;
        }

        public Block(IReadOnlyCollection<IView> children)
        {
            Children = children;
        }

        public IReadOnlyCollection<IView> Children { get; }

        public void Render(IRenderer renderer)
        {
            foreach (var child in Children)
            {
                child.Render(renderer);
                renderer.Render("\n");
            }
        }
    }
}

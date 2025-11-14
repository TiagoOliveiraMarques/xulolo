using Xulolo.Renderer;

namespace Xulolo.View
{
    /// <summary>
    /// Represents a view element that can display a visual focus indicator and contains a single child view.   
    /// </summary>
    /// <remarks>Use this type to wrap a child view and visually indicate whether it is focused. The focus
    /// state affects how the element is rendered, typically by adding a prefix or highlight. This type is intended for
    /// internal use within view composition and rendering logic.</remarks>
    public class FocusableElement : IView
    {
        public FocusableElement(bool focused, IView child)
        {
            Focused = focused;
            Child = child;
        }

        public bool Focused { get; }
        public IView Child { get; }

        public void Render(IRenderer renderer)
        {
            var prefix = Focused ? "❯ " : "  ";

            renderer.Render(prefix);
            Child.Render(renderer);
        }
    }
}

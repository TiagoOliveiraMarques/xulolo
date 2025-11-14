using Xulolo.Renderer;

namespace Xulolo.View
{
    /// <summary>
    /// Represents a text box view that displays a specified string for editing.  
    /// </summary>
    public class Textbox : IView
    {
        public Textbox(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public void Render(IRenderer renderer)
        {
            renderer.Render("✎ ");
            renderer.Render(" ");
            renderer.Render(Text);
        }
    }
}

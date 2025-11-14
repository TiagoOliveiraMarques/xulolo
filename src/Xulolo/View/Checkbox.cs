using Xulolo.Renderer;

namespace Xulolo.View
{
    /// <summary>
    /// View component that represents a checkbox with a label.
    /// The checkbox can be either checked or unchecked.
    /// </summary>
    public sealed class Checkbox : IView
    {
        public Checkbox(string text, bool @checked)
        {
            Text = text;
            Checked = @checked;
        }

        public string Text { get; }
        public bool Checked { get; }

        public void Render(IRenderer renderer)
        {
            var prefix = Checked ? "✅ " : "🔲 ";

            renderer.Render(prefix);
            renderer.Render(Text);
        }
    }
}

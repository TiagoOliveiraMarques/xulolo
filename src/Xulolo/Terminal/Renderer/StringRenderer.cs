using System.Text;

namespace Xulolo.Terminal.Renderer
{
    public class StringRenderer : IRenderer
    {
        private readonly StringBuilder sb = new();

        public string Content => sb.ToString();

        public void Flush()
        {
            sb.Clear();
        }

        public void Render(ReadOnlySpan<char> text)
        {
            sb.Append(text);
        }
    }
}

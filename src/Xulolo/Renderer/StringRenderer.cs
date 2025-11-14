using System.Text;

namespace Xulolo.Renderer
{
    public class StringRenderer : IRenderer
    {
        private readonly StringBuilder _sb = new();

        public string Content => _sb.ToString();

        public void Flush()
        {
            _sb.Clear();
        }

        public void Render(ReadOnlySpan<char> text)
        {
            _sb.Append(text);
        }
    }
}

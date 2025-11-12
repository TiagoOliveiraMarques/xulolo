using System.Text;

namespace Xulolo.Terminal.Renderer
{
    internal class DefaultRenderer : IRenderer
    {
        public DefaultRenderer()
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Render(ReadOnlySpan<char> text)
        {
            Console.Out.Write(text);
        }
    }
}

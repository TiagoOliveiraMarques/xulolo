using System.Buffers;
using System.Text;

namespace Xulolo.Terminal.Renderer
{
    internal class DefaultRenderer : IRenderer
    {
        private readonly ArrayBufferWriter<char> _buffer;

        public DefaultRenderer()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            _buffer = new ArrayBufferWriter<char>(1024);
        }

        public void Render(ReadOnlySpan<char> text)
        {
            _buffer.Write(text);
        }

        public void Flush()
        {
            Console.SetCursorPosition(0, 0);
            Console.Out.Write(_buffer.WrittenSpan);
            _buffer.Clear();
        }
    }
}

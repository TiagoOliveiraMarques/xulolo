using System.Buffers;
using System.Text;

namespace Xulolo.Terminal.Renderer
{
    internal class DefaultRenderer : IRenderer
    {
        private ArrayBufferWriter<char> _currentFrameBuffer;
        private ArrayBufferWriter<char> _previousFrameBuffer;

        public DefaultRenderer(int initialBufferCapacity = 1024)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            _currentFrameBuffer = new ArrayBufferWriter<char>(initialBufferCapacity);
            _previousFrameBuffer = new ArrayBufferWriter<char>(initialBufferCapacity);
        }

        public void Render(ReadOnlySpan<char> text)
        {
            _currentFrameBuffer.Write(text);
        }

        public void Flush()
        {
            Console.SetCursorPosition(0, 0);

            // Split both buffers in lines
            // Only render lines that are different
            // Stupid and simple for now
            var oldLines = _previousFrameBuffer.WrittenSpan.ToString().Split('\n');
            var newLines = _currentFrameBuffer.WrittenSpan.ToString().Split('\n');

            for (int i = 0; i < Math.Max(oldLines.Length, newLines.Length); i++)
            {
                var oldLine = i < oldLines.Length ? oldLines[i] : string.Empty;
                var newLine = i < newLines.Length ? newLines[i] : string.Empty;
                if (oldLine != newLine)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Out.Write(newLine);

                    // clear any characters left by the old line
                    if (oldLine.Length > newLine.Length)
                    {
                        Console.Out.Write(new string(' ', oldLine.Length - newLine.Length));
                    }
                }
            };

            PrepareNewBuffer();
        }

        private void PrepareNewBuffer()
        {
            var newCurrent = _previousFrameBuffer;
            var newPrevious = _currentFrameBuffer;

            newCurrent.Clear();

            _currentFrameBuffer = newCurrent;
            _previousFrameBuffer = newPrevious;
        }
    }
}

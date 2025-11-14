using System.Buffers;
using System.Text;

namespace Xulolo.Renderer
{
    /// <summary>
    /// <see cref="IRenderer"/> implementation that renders directly to the console.
    /// It uses a double buffer to minimize flickering. When flushing, the buffer from the previous
    /// frame and the buffer from the current frame are compared and only the different cells are
    /// renderer.
    /// </summary>
    internal class DefaultRenderer : IRenderer
    {
        private ArrayBufferWriter<char> _currentFrame;
        private ArrayBufferWriter<char> _previousFrame;

        /// <summary>
        /// Creates a new instance of a <see cref="DefaultRenderer"/>.
        /// </summary>
        /// <param name="initialBufferCapacity">Initial size of the rendering buffers.</param>
        public DefaultRenderer(int initialBufferCapacity = 256)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;

            _currentFrame = new ArrayBufferWriter<char>(initialBufferCapacity);
            _previousFrame = new ArrayBufferWriter<char>(initialBufferCapacity);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="text"></param>
        public void Render(ReadOnlySpan<char> text)
        {
            _currentFrame.Write(text);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Flush()
        {
            Console.SetCursorPosition(0, 0);

            // iterate the lines of the new buffer and compare then against the previous buffer.
            // since most TUI applications will be line oriented, we only re-render lines that have changed.
            var previousFrameSpan = _previousFrame.WrittenSpan;
            var currentFrameSpan = _currentFrame.WrittenSpan;
            
            for (var line = 0; !(previousFrameSpan.IsEmpty && currentFrameSpan.IsEmpty); line++)
            {
                var previousLine = previousFrameSpan.ConsumeLine();
                var currentLine = currentFrameSpan.ConsumeLine();

                if (!previousLine.SequenceEqual(currentLine))
                {
                    Console.SetCursorPosition(0, line);
                    Console.Out.Write(currentLine);

                    var previousLineLength = Encoding.UTF8.GetByteCount(previousLine);
                    var currentLineLength = Encoding.UTF8.GetByteCount(currentLine);
                    var rightPadding = Math.Max(0, previousLineLength - currentLineLength);
                    if (rightPadding > 0)
                    {
                        for (var j = 0; j < rightPadding; j++)
                            Console.Out.Write(' ');
                    }

                    Console.Out.Write('\n');
                }
            }

            SwapBuffers();
        }

        private void SwapBuffers()
        {
            (_previousFrame, _currentFrame) = (_currentFrame, _previousFrame);
            _currentFrame.Clear();
        }
    }
}

namespace Xulolo.Renderer
{
    public static class ReadOnlySpanExtensions
    {
        public static ReadOnlySpan<char> ConsumeLine(this ref ReadOnlySpan<char> span)
        {
            var cursor = 0;
            while (cursor < span.Length && span[cursor] != '\n')
                cursor++;

            var result = span[..cursor];

            if (cursor < span.Length && span[cursor] == '\n')
                cursor++;
            span = span[cursor..];

            return result;
        }
    }
}

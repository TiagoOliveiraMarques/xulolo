namespace Xulolo.Terminal.Renderer
{
    public interface IRenderer
    {
        void Render(ReadOnlySpan<char> text);

        void Flush();
    }
}

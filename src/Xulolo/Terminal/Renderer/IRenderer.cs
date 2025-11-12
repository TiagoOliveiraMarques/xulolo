namespace Xulolo.Terminal.Renderer
{
    public interface IRenderer
    {
        void Clear();

        void Render(ReadOnlySpan<char> text);
    }
}

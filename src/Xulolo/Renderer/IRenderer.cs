namespace Xulolo.Renderer
{
    /// <summary>
    /// Interface responsible for interoping between the view (which holds 
    /// information about which logical elements to render) and the actual
    /// console rendering implementation.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Renders the specified text to the output surface.
        /// </summary>
        /// <param name="text">A read-only span of characters containing the text to render.</param>
        void Render(ReadOnlySpan<char> text);

        /// <summary>
        /// Signals that all the rendering for the current frame has been done
        /// and all the buffered data should be sent to the console.
        /// </summary>
        void Flush();
    }
}

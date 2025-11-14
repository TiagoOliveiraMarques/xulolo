using Xulolo.Renderer;
using Xulolo.View;

namespace Xulolo.Tests.View
{
    public class TextboxTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("lorem ipsum")]
        public Task TextBoxShouldRenderProperly(string text)
        {
            var textbox = new Textbox(text);
            var renderer = new StringRenderer();
            
            textbox.Render(renderer);

            return Verify(renderer.Content).UseParameters(text);
        }
    }
}

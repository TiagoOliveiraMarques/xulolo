using Xulolo.Renderer;
using Xulolo.View;

namespace Xulolo.Tests.View
{
    public class FocusableElementTest
    {
        [Theory]
        [InlineData("when focused", true)]
        [InlineData("when not focused", false)]
        public Task FocusableElementShouldRenderProperly(string scenario, bool focused)
        {
            var view = new FocusableElement(focused, new Textbox("Sample Text"));
            var renderer = new StringRenderer();

            view.Render(renderer);

            return Verify(renderer.Content).UseParameters(scenario);
        }
    }
}

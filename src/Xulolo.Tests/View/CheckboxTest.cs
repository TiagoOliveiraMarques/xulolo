using Xulolo.Renderer;
using Xulolo.View;

namespace Xulolo.Tests.View
{
    public class CheckboxTest
    {
        [Theory]
        [InlineData("not checked empty string", "", false)]
        [InlineData("checked empty string", "", true)]
        [InlineData("not checked with text", "lorem ipsum", false)]
        [InlineData("checked with text", "lorem ipsum", true)]
        public Task CheckboxShouldRenderProperly(string scenario, string text, bool @checked)
        {
            var checkbox = new Checkbox(text, @checked);
            var renderer = new StringRenderer();

            checkbox.Render(renderer);

            return Verify(renderer.Content).UseParameters(scenario);
        }
    }
}

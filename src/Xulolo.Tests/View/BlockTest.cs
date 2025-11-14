using Xulolo.Renderer;
using Xulolo.View;

namespace Xulolo.Tests.View
{
    public class BlockTest
    {
        [Fact]
        public Task BlockWithNoChildrenShouldRenderProperly()
        {
            var block = new Block();
            var renderer = new StringRenderer();
            block.Render(renderer);

            return Verify(renderer.Content);
        }

        [Fact]
        public Task BlockWithSingleChildShouldRenderProperly()
        {
            var block = new Block(new Textbox("Sample Text"));
            var renderer = new StringRenderer();

            block.Render(renderer);

            return Verify(renderer.Content);
        }

        [Fact]
        public Task BlockWithMultipleChildrenShouldRenderProperly()
        {
            var block = new Block(
                new Textbox("First Textbox"),
                new Checkbox("Sample Checkbox", true),
                new Textbox("Second Textbox")
            );
            var renderer = new StringRenderer();
            
            block.Render(renderer);

            return Verify(renderer.Content);
        }
    }
}

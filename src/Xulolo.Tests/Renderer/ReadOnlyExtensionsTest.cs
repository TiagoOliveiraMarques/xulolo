using Xulolo.Renderer;

namespace Xulolo.Tests.Renderer
{
    public class ReadOnlyExtensionsTest
    {
        [Theory]
        [InlineData("", "", "")]
        [InlineData("lorem ipsum", "", "lorem ipsum")]
        [InlineData("lorem\nipsum", "ipsum", "lorem")]
        public void ConsumeLineShouldReturnNextLine(string input, string expectedRemaining, string expectedOutput)
        {
            var inputSpan = input.AsSpan();
            var actual = inputSpan.ConsumeLine();

            Assert.Equal(expectedOutput, actual.ToString());
            Assert.Equal(expectedRemaining, inputSpan.ToString());
        }
    }
}

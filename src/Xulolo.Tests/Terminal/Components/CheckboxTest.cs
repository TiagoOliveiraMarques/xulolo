using System.Runtime.Serialization;
using Xulolo.Terminal.Components;
using Xulolo.Terminal.Events;
using Xulolo.Terminal.Renderer;

namespace Xulolo.Tests.Terminal.Components
{
    public class CheckboxTest
    {
        [Fact]
        public void NewCheckboxShouldNotBeCheckedByDefault()
        {
            var checkbox = new Checkbox("text");

            Assert.False(checkbox.Checked);
            Assert.False(checkbox.Focused);
        }

        [Fact]
        public void SendingEnterKeyToUnfocusedCheckboxShouldNotToggle()
        {
            var checkbox = new Checkbox("text");
            Assert.False(checkbox.Checked);
            Assert.False(checkbox.Focused);

            checkbox.Update(new TerminalKeyEvent(ConsoleKey.Enter));
            Assert.False(checkbox.Focused);
            Assert.False(checkbox.Checked);
        }

        [Fact]
        public void SendingEnterKeyToFocusedCheckboxShouldToggle()
        {
            var checkbox = new Checkbox("text");
            Assert.False(checkbox.Checked);
            checkbox.Focused = true;

            checkbox.Update(new TerminalKeyEvent(ConsoleKey.Enter));
            Assert.True(checkbox.Focused);
            Assert.True(checkbox.Checked);
        }

        [Theory]
        [MemberData(nameof(AllKeysButEnter))]
        public void SendingRandomKeyOtherThanEnterToFocusedCheckboxShouldNotTriggerToggle(ConsoleKey key)
        {
            var checkbox = new Checkbox("text");
            checkbox.Focused = true;
            checkbox.Checked = false;

            checkbox.Update(new TerminalKeyEvent(key));
            Assert.True(checkbox.Focused);
            Assert.False(checkbox.Checked);
        }

        [Fact]
        public Task RenderUncheckedCheckbox()
        {
            var checkbox = new Checkbox("text");
            checkbox.Checked = false;

            var renderer = new StringRenderer();
            checkbox.Render(renderer);

            return Verify(renderer.Content);
        }

        public static IEnumerable<object[]> AllKeysButEnter => Enum
            .GetValues<ConsoleKey>()
            .Where(x => x != ConsoleKey.Enter)
            .Select(x => new object[] { x })
            .ToList();
    }
}

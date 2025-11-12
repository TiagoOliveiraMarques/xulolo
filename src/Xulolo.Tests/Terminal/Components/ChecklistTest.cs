using Xulolo.Terminal.Components;
using Xulolo.Terminal.Events;
using Xulolo.Terminal.Renderer;

namespace Xulolo.Tests.Terminal.Components
{
    public class ChecklistTest
    {
        [Fact]
        public Task EmptyChecklistShouldRenderProperly()
        {
            var checklist = new Checklist();
            var renderer = new StringRenderer();
            checklist.Render(renderer);

            return Verify(renderer.Content);
        }

        [Fact]
        public Task ChecklistWithMixedCheckedAndUncheckedItems()
        {
            var checklist = new Checklist(new Checkbox("text 1"), new Checkbox("test 2"));
            var renderer = new StringRenderer();

            checklist.Render(renderer);

            return Verify(renderer.Content);
        }

        [Fact]
        public Task ChecklistAfterPressingUpArrowNTimesShouldNotGoBeyondFirstItem()
        {
            var checklist = new Checklist(new Checkbox("text 1"), new Checkbox("test 2"));
            var renderer = new StringRenderer();

            checklist.Update(new TerminalKeyEvent(ConsoleKey.UpArrow));
            checklist.Update(new TerminalKeyEvent(ConsoleKey.UpArrow));
            checklist.Update(new TerminalKeyEvent(ConsoleKey.UpArrow));

            checklist.Render(renderer);

            return Verify(renderer.Content);
        }

        [Fact]
        public Task ChecklistAfterPressingDownArrowNTimesShouldNotGoBeyondLastItem()
        {
            var checklist = new Checklist(new Checkbox("text 1"), new Checkbox("test 2"));
            var renderer = new StringRenderer();

            checklist.Update(new TerminalKeyEvent(ConsoleKey.DownArrow));
            checklist.Update(new TerminalKeyEvent(ConsoleKey.DownArrow));
            checklist.Update(new TerminalKeyEvent(ConsoleKey.DownArrow));

            checklist.Render(renderer);

            return Verify(renderer.Content);
        }

        [Fact]
        public Task ChecklistAfterPressingDownArrowOnce()
        {
            var checklist = new Checklist(new Checkbox("text 1"), new Checkbox("test 2"), new Checkbox("test 3"));
            var renderer = new StringRenderer();

            checklist.Update(new TerminalKeyEvent(ConsoleKey.DownArrow));

            checklist.Render(renderer);

            return Verify(renderer.Content);
        }

        [Fact]
        public Task ChecklistAfterTogglingOneCheckbox()
        {
            var checklist = new Checklist(new Checkbox("text 1"), new Checkbox("test 2"), new Checkbox("test 3"));
            var renderer = new StringRenderer();

            checklist.Update(new TerminalKeyEvent(ConsoleKey.Enter));
            checklist.Render(renderer);

            return Verify(renderer.Content);
        }

        [Fact]
        public Task ChecklistAfterTogglingTheSameItemTwice()
        {
            var checklist = new Checklist(new Checkbox("text 1"), new Checkbox("test 2"), new Checkbox("test 3"));
            var renderer = new StringRenderer();

            checklist.Update(new TerminalKeyEvent(ConsoleKey.End));
            checklist.Update(new TerminalKeyEvent(ConsoleKey.End));
            checklist.Render(renderer);

            return Verify(renderer.Content);
        }

        [Fact]
        public Task ChecklistAfterPressingDownOnceAndTogglingItem()
        {
            var checklist = new Checklist(new Checkbox("text 1"), new Checkbox("test 2"), new Checkbox("test 3"));
            var renderer = new StringRenderer();

            checklist.Update(new TerminalKeyEvent(ConsoleKey.DownArrow));
            checklist.Update(new TerminalKeyEvent(ConsoleKey.Enter));

            checklist.Render(renderer);

            return Verify(renderer.Content);
        }
    }
}

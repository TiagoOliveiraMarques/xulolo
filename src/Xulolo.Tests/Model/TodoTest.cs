namespace Xulolo.Tests.Model
{
    public class TodoTest
    {
        [Fact]
        public void NewTodoShouldNotBeDone()
        {
            var text = "test todo";
            var todo = new Xulolo.Model.Todo(text);
            Assert.Equal(text, todo.Text);
            Assert.False(todo.Done);
        }

        [Fact]
        public void NewTodoShouldHaveUniqueId()
        {
            var todo1 = new Xulolo.Model.Todo("Test todo 1");
            var todo2 = new Xulolo.Model.Todo("Test todo 2");
            Assert.NotEqual(todo1.Id, todo2.Id);
        }

        [Fact]
        public void MarkAsDoneShouldSetDoneToTrue()
        {
            var todo = new Xulolo.Model.Todo("Test todo");
            todo.MarkAsDone();
            Assert.True(todo.Done);
        }
    }
}

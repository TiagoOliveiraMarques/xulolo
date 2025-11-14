using Xulolo.Model;

namespace Xulolo.Tests.Model
{
    public class ModelManagerTest
    {
        [Fact]
        public void NewModelManagerShouldHaveNoTodos()
        {
            var manager = new ModelManager();
            Assert.Empty(manager.Todos);
        }

        [Fact]
        public void AddNewTodoShouldIncreaseNumberOfTodos()
        {
            var manager = new ModelManager();
            var todo = new Todo("Test todo");
            manager.AddTodo(todo);
            Assert.Single(manager.Todos);
        }

        [Fact]
        public void RemoveTodoShouldDecreaseNumberOfTodos()
        {
            var manager = new ModelManager();
            var todo = new Todo("Test todo");
            manager.AddTodo(todo);
            manager.RemoveTodo(todo.Id);
            Assert.Empty(manager.Todos);
        }
    }
}

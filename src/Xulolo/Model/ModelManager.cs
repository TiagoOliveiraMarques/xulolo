namespace Xulolo.Model
{
    public sealed class ModelManager
    {
        private List<Todo> _todos = new();

        public IEnumerable<Todo> Todos => _todos.AsReadOnly();

        public void AddTodo(Todo todo)
        {
            ArgumentNullException.ThrowIfNull(todo);
            _todos.Add(todo);
        }

        public void RemoveTodo(Guid id)
        {
            _todos.RemoveAll(t => t.Id == id);
        }

    }
}

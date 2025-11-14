using Xulolo.Model;
using Xulolo.View;

namespace Xulolo.ViewModel
{
    internal class TodoList : IViewModel
    {
        private readonly ModelManager _model;
        private string _newTodoText = string.Empty;
        private int _focusedElement = 0;

        public TodoList(ModelManager model)
        {
            _model = model;
        }

        public IView View()
        {
            var textbox = new Textbox(_newTodoText);
            var checkboes = _model.Todos.Select(t => new Textbox(t.Text));
            var elements = new List<IView> { textbox };
            elements.AddRange(checkboes);

            elements[_focusedElement] = new FocusableElement(true, elements[_focusedElement]);

            return new Block(elements);
        }
    }
}

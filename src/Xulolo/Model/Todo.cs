namespace Xulolo.Model
{
    public sealed class Todo
    {
        public Todo(string text)
        {
            Id = Guid.CreateVersion7();
            Text = text;
            Done = false;
        }

        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public bool Done { get; private set; }

        public void MarkAsDone()
        {
            Done = true;
        }
    }
}

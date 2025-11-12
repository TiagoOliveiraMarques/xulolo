using Xulolo.Terminal.Components;
using Xulolo.Terminal.Events;
using Xulolo.Terminal.Renderer;

var cts = new CancellationTokenSource();

Console.CancelKeyPress += Console_CancelKeyPress;
void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
{
    cts.Cancel();
}

var renderer = new DefaultRenderer();
var eventOutbox = new EventOutbox(capacity: 100);
await using var eventSources = new EventSourceCoordinator(
    cts.Token,
    new ConsoleEventSource(eventOutbox)
);

var componentModel = new Checklist(
    new TextInput(),
    new Checkbox("todo 1"),
    new Checkbox("todo 2"));

// event loop
while (!cts.IsCancellationRequested)
{
    renderer.Clear();
    componentModel.Render(renderer);

    var @event = await eventOutbox.ReceiveAsync(cts.Token);
    componentModel.Update(@event);
}

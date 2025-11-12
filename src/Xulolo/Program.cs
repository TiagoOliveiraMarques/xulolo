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
var componentModel = new Checklist(new Checkbox("todo 1"),new Checkbox("todo 2"));

// event loop
while (!cts.IsCancellationRequested)
{
    renderer.Clear();
    componentModel.Render(renderer);

    // todo: if we need timers and such we might need some abstraction here to pull
    // events from a channel
    var key = Console.ReadKey(true);
    var @event = new TerminalKeyEvent(key.Key);
    componentModel.Update(@event);
}

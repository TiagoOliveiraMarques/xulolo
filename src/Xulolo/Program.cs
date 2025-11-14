
using Xulolo.Events;
using Xulolo.Model;
using Xulolo.Renderer;
using Xulolo.ViewModel;

var cts = new CancellationTokenSource();

Console.CancelKeyPress += Console_CancelKeyPress;
void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
{
    cts.Cancel();
}

var renderer = new DefaultRenderer();
var model = new ModelManager();
var viewModel = new TodoList(model);
var eventSource = new ConsoleEventSource(outboxCapacity: 10);

while (!cts.IsCancellationRequested)
{
    var view = viewModel.View();
    view.Render(renderer);

    renderer.Flush();

    var @event = await eventSource.ChannelReader.ReadAsync(cts.Token);
    viewModel.Handle(@event);
}

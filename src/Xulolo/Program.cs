
using Xulolo.Model;
using Xulolo.Renderer;
using Xulolo.View;
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

var view = viewModel.View();

view.Render(renderer);
renderer.Flush();

Console.ReadKey(true);

renderer.Render("a");
renderer.Flush();

Console.ReadKey(true);
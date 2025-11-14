
using Xulolo.Renderer;
using Xulolo.View;

var cts = new CancellationTokenSource();

Console.CancelKeyPress += Console_CancelKeyPress;
void Console_CancelKeyPress(object? sender, ConsoleCancelEventArgs e)
{
    cts.Cancel();
}

var renderer = new DefaultRenderer();

var view = new Block(
    new FocusableElement(false, new Textbox("")),
    new FocusableElement(true, new Checkbox("todo 1", false)),
    new FocusableElement(false, new Checkbox("todo 2", true))
    );

view.Render(renderer);
renderer.Flush();

Console.ReadKey(true);

renderer.Render("a");
renderer.Flush();

Console.ReadKey(true);
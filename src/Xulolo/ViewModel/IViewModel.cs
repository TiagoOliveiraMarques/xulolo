using Xulolo.Events;
using Xulolo.View;

namespace Xulolo.ViewModel
{
    public interface IViewModel
    {
        void Handle(Event @event);

        IView View();
    }
}

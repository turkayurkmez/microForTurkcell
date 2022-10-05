using Order.API.Commands;

namespace Order.API.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}

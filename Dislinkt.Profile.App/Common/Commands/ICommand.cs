using MediatR;

namespace Dislinkt.Profile.App.Common.Commands
{
    public interface ICommand<out T> : IRequest
    {
        T Request { get; }
    }
}

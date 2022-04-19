using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Domain.Common.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Execute(TCommand command, CancellationToken cancellationToken);
    }
}

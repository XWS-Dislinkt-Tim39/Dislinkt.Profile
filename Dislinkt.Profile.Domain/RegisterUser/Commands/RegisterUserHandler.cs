using Dislinkt.Profile.Domain.Common.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Domain.RegisterUser.Create
{
    class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
    {
        public async Task Execute(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

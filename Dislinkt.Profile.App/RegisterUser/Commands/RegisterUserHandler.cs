using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.RegisterUser.Commands
{
    class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAddress(request.Request.EmailAddress);

            if(existingUser != null)
            {
                return false;
            }

            await _userRepository.CreateUser(new Domain.Users.User(Guid.NewGuid(), request.Request.FirstName, request.Request.LastName,
                request.Request.EmailAddress, request.Request.Password, request.Request.Address, request.Request.City, request.Request.Country,
                request.Request.PhoneNumber, (Domain.Users.Gender)request.Request.Gender, false, Domain.Users.VisibilityStatus.Public));

            return true;
        }
    }
}

using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Interests.Commands.AddInterestToUser
{
    public class AddInterestToUserHandler : IRequestHandler<AddInterestToUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public AddInterestToUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(AddInterestToUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Request.UserId);

            if (existingUser == null) return false;

            var updatedInterests = existingUser.Interests.Append(request.Request.Id).ToArray();

            await _userRepository.AddInterestAsync(new Domain.Users.User(existingUser.Id, existingUser.FirstName, existingUser.LastName,
                existingUser.Username, existingUser.Biography, existingUser.EmailAddress, existingUser.Password, existingUser.DateOfBirth, existingUser.Address,
                existingUser.City, existingUser.Country, existingUser.PhoneNumber, existingUser.Gender, existingUser.IsApproved, existingUser.Status,
                existingUser.Educations, existingUser.WorkExperiences, existingUser.Skills, updatedInterests));

            return true;
        }
    }
}

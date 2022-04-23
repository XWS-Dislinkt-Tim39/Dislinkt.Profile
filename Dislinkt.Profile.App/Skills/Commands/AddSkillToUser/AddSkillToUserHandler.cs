using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Skills.Commands.AddSkillToUser
{
    public class AddSkillToUserHandler : IRequestHandler<AddSkillToUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public AddSkillToUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(AddSkillToUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetById(request.Request.UserId);

            if (existingUser == null) return false;

            var updatedSkills = existingUser.Skills.Append(request.Request.Id).ToArray();

            await _userRepository.AddSkillAsync(new Domain.Users.User(existingUser.Id, existingUser.FirstName, existingUser.LastName,
                existingUser.Username, existingUser.EmailAddress, existingUser.Password, existingUser.DateOfBirth, existingUser.Address,
                existingUser.City, existingUser.Country, existingUser.PhoneNumber, existingUser.Gender, existingUser.IsApproved, existingUser.Status,
                existingUser.Educations, existingUser.WorkExperiences, updatedSkills));

            return true;
        }
    }
}

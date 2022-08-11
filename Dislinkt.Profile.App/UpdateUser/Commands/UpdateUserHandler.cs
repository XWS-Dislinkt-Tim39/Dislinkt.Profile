using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.UpdateUser.Commands
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Request.Id);

            if (existingUser == null) return null;

            var updatedUser = new User(request.Request.Id, request.Request.FirstName, request.Request.LastName, request.Request.FirstName + " " + request.Request.LastName,
               request.Request.Biography, request.Request.EmailAddress, existingUser.Password, request.Request.DateOfBirth, request.Request.Address, request.Request.City,
                request.Request.Country, request.Request.PhoneNumber, (Gender)request.Request.Gender, 
                existingUser.IsApproved, existingUser.Status, existingUser.Educations, 
                existingUser.WorkExperiences, existingUser.Skills, existingUser.Interests,MapSeniorityData(request.Request.Seniority),Role.User);

            await _userRepository.UpdateUserAsync(updatedUser);

            return updatedUser;
        }
        private Seniority MapSeniorityData(SeniorityData seniorityData)
        {
            if (seniorityData == SeniorityData.Junior) return Seniority.Junior;
            if (seniorityData == SeniorityData.Medior) return Seniority.Medior;
            if (seniorityData == SeniorityData.Senior) return Seniority.Senior;

            return Seniority.Junior;
        }
    }
}

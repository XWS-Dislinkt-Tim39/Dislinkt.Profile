using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Educations.Commands
{
    class EducationHandler : IRequestHandler<EducationCommand, bool>
    {
        private IUserRepository _userRepository;
        public EducationHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(EducationCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetById(request.Request.UserId);

            if (existingUser == null) return false;

            var educations = existingUser.Educations.Any() ? existingUser.Educations : Array.Empty<Education>();

            var updatedEducations = educations.Append(new Education(Guid.NewGuid(), request.Request.UserId, request.Request.NameOfSchool, request.Request.FieldOfStudy, request.Request.StartDate, request.Request.EndDate, request.Request.Description));

            await _userRepository.AddEducationAsync(new User(existingUser.Id, existingUser.FirstName, existingUser.LastName, existingUser.Username,
                existingUser.EmailAddress, existingUser.Password, existingUser.DateOfBirth, existingUser.Address, existingUser.City, existingUser.Country,
                existingUser.PhoneNumber, existingUser.Gender, existingUser.IsApproved, 
                existingUser.Status, updatedEducations.ToArray(), existingUser.WorkExperiences, existingUser.Skills, existingUser.Interests));

            return true;
        }
    }
}

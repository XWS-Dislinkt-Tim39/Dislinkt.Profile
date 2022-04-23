using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Interests.Commands.NewInterest
{
    public class NewInterestHandler : IRequestHandler<NewInterestCommand, bool>
    {
        private readonly IInterestRepository _interestRepository;
        private readonly IUserRepository _userRepository;
        public NewInterestHandler(IInterestRepository interestRepository, IUserRepository userRepository)
        {
            _interestRepository = interestRepository;
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(NewInterestCommand request, CancellationToken cancellationToken)
        {
            var newInterest = new Domain.Users.Interest(Guid.NewGuid(), request.Request.Name);
            await _interestRepository.AddAsync(newInterest);

            var existingUser = await _userRepository.GetById(request.Request.UserId);

            if (existingUser == null) return false;

            var updatedInterests = existingUser.Interests.Append(newInterest.Id);

            await _userRepository.AddInterestAsync(new Domain.Users.User(existingUser.Id, existingUser.FirstName, existingUser.LastName,
                existingUser.Username, existingUser.EmailAddress, existingUser.Password, existingUser.DateOfBirth, existingUser.Address,
                existingUser.City, existingUser.Country, existingUser.PhoneNumber, existingUser.Gender, existingUser.IsApproved, existingUser.Status,
                existingUser.Educations, existingUser.WorkExperiences, existingUser.Skills, updatedInterests.ToArray()));

            return true;
        }
    }
}

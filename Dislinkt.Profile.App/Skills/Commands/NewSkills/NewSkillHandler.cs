using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Skills.Commands.NewSkills
{
    class NewSkillHandler : IRequestHandler<NewSkillCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        public NewSkillHandler(IUserRepository userRepository, ISkillRepository skillRepository)
        {
            _userRepository = userRepository;
            _skillRepository = skillRepository;
        }
        public async Task<bool> Handle(NewSkillCommand request, CancellationToken cancellationToken)
        {
            var newSkill = new Domain.Users.Skill(Guid.NewGuid(), request.Request.Name);
            await _skillRepository.AddAsync(newSkill);

            var existingUser = await _userRepository.GetByIdAsync(request.Request.UserId);

            if (existingUser == null) return false;

            var updatedSkills = existingUser.Skills.Append(newSkill.Id);

            await _userRepository.AddSkillAsync(new Domain.Users.User(existingUser.Id, existingUser.FirstName, existingUser.LastName,
                existingUser.Username, existingUser.Biography, existingUser.EmailAddress, existingUser.Password, existingUser.DateOfBirth, existingUser.Address,
                existingUser.City, existingUser.Country, existingUser.PhoneNumber, existingUser.Gender, existingUser.IsApproved, existingUser.Status,
                existingUser.Educations, existingUser.WorkExperiences, updatedSkills.ToArray(), existingUser.Interests,existingUser.Seniority, existingUser.Role));

            return true;
        }
    }
}

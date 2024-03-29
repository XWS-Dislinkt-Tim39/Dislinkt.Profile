﻿using Dislinkt.Profile.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Dislinkt.Profile.Domain.Users;

namespace Dislinkt.Profile.App.WorkExperiences
{
    public class WorkExcperienceHandler : IRequestHandler<WorkExperienceCommand, bool>
    {
        private IUserRepository _userRepository;
        public WorkExcperienceHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(WorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.Request.UserId);

            if (existingUser == null) return false;

            var updatedWorkExperience = existingUser.WorkExperiences.Append(new Domain.Users.WorkExperience(System.Guid.NewGuid(), request.Request.UserId, request.Request.NameOfCompany,
                request.Request.FieldOfWork, request.Request.StartDate, request.Request.EndDate, request.Request.Description, MapSeniorityData(request.Request.Seniority)));

            await _userRepository.AddWorkExperienceAsync(new Domain.Users.User(existingUser.Id, existingUser.FirstName, existingUser.LastName,
                existingUser.Username, existingUser.Biography, existingUser.EmailAddress, existingUser.Password, existingUser.DateOfBirth, existingUser.Address,
                existingUser.City, existingUser.Country, existingUser.PhoneNumber, existingUser.Gender, existingUser.IsApproved, existingUser.Status,
                existingUser.Educations, updatedWorkExperience.ToArray(), existingUser.Skills, existingUser.Interests,existingUser.Seniority,existingUser.Role));

            return true;
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

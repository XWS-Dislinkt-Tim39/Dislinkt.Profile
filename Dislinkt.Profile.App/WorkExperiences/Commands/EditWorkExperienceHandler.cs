﻿using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.WorkExperiences.Commands
{
    public class EditWorkExperienceHandler : IRequestHandler<EditWorkExperienceCommand, WorkExperience>
    {
        private readonly IWorkExperienceRepository _experienceRepository;
        public EditWorkExperienceHandler(IWorkExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }
        public async Task<WorkExperience> Handle(EditWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var existingWorkExperience = await _experienceRepository.GetByIdAsync(request.Request.Id);

           // if (existingWorkExperience == null) return null;

            var updatedWorkExperience = new WorkExperience(request.Request.Id, request.Request.UserId, request.Request.NameOfCompany, request.Request.FieldOfWork,
                request.Request.StartDate, request.Request.EndDate, request.Request.Description, MapSeniorityData(request.Request.Seniority)
                );


            await _experienceRepository.UpdateWorkExperienceAsync(request.Request);

            return updatedWorkExperience;
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

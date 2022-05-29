using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.Educations.Commands
{
    public class UpdateEducationHandler : IRequestHandler<UpdateEducationCommand, Education>
    {
        private readonly IEducationRepository _educationRepository;
        public UpdateEducationHandler(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }
        public async Task<Education> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var existingEducation = await _educationRepository.GetByIdAsync(request.Request.Id);

            // if (existingWorkExperience == null) return null;

            var updatedEducation = new Education(request.Request.Id, request.Request.UserId, request.Request.NameOfSchool, request.Request.FieldOfStudy,
                request.Request.StartDate, request.Request.EndDate, request.Request.Description
                );


            await _educationRepository.UpdateEducationAsync(request.Request);

            return updatedEducation;
        }
    }
}

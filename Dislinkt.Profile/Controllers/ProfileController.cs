using Dislinkt.Profile.App.Educations.Commands;
using Dislinkt.Profile.App.Interests.Commands.AddInterestToUser;
using Dislinkt.Profile.App.Interests.Commands.NewInterest;
using Dislinkt.Profile.App.RegisterUser.Commands;
using Dislinkt.Profile.App.SignUpUser.Commands;
using Dislinkt.Profile.App.Skills.Commands.AddSkillToUser;
using Dislinkt.Profile.App.Skills.Commands.NewSkills;
using Dislinkt.Profile.App.UpdateUser.Commands;
using Dislinkt.Profile.App.WorkExperiences;
using Dislinkt.Profile.Application;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dislinkt.Profile.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <returns>A boolean status of registration</returns>
        /// /// <param name="userData">for user</param>
        [HttpPost]
        [Route("/register-user")]
        public async Task<bool> RegisterUserAsync(UserData userData)
        {
            return await _mediator.Send(new RegisterUserCommand(userData));

        }
        /// <summary>
        /// Update existing user
        /// </summary>
        /// <returns>Updated user</returns>
        /// /// <param name="updateUserData">for user</param>
        [HttpPost]
        [Route("/update-user")]
        public async Task<User> UpdateUserAsync(UpdateUserData updateUserData)
        {
            return await _mediator.Send(new UpdateUserCommand(updateUserData));

        }
        /// <summary>
        /// Add education
        /// </summary>
        /// <returns>A boolean status of adding education to user</returns>
        /// /// <param name="educationData">for user</param>
        [HttpPost]
        [Route("/add-education")]
        public async Task<bool> AddEducation(EducationData educationData)
        {
            return await _mediator.Send(new EducationCommand(educationData));

        }
        /// <summary>
        /// Add work experience
        /// </summary>
        /// <returns>A boolean status of adding work experience to user</returns>
        /// /// <param name="workExperienceData">for user</param>
        [HttpPost]
        [Route("/add-work-experience")]
        public async Task<bool> AddWorkExperience(WorkExperienceData workExperienceData)
        {
            return await _mediator.Send(new WorkExperienceCommand(workExperienceData));

        }
        /// <summary>
        /// Add new skill
        /// </summary>
        /// <returns>A boolean status of adding skill to user</returns>
        /// /// <param name="skillAddedData">for user</param>
        [HttpPost]
        [Route("/add-new-skill")]
        public async Task<bool> AddNewSkill(SkillAddedData skillAddedData)
        {
            return await _mediator.Send(new NewSkillCommand(skillAddedData));

        }
        /// <summary>
        /// Add existing skill
        /// </summary>
        /// <returns>A boolean status of adding skill to user</returns>
        /// /// <param name="skillData">for user</param>
        [HttpPost]
        [Route("/add-skill")]
        public async Task<bool> AddSkill(SkillData skillData)
        {
            return await _mediator.Send(new AddSkillToUserCommand(skillData));

        }
        /// <summary>
        /// Add new interest
        /// </summary>
        /// <returns>A boolean status of adding interest to user</returns>
        /// /// <param name="interestAddedData">for user</param>
        [HttpPost]
        [Route("/add-new-interest")]
        public async Task<bool> AddNewInterest(InterestAddedData interestAddedData)
        {
            return await _mediator.Send(new NewInterestCommand(interestAddedData));

        }
        /// <summary>
        /// Add existing interest
        /// </summary>
        /// <returns>A boolean status of adding interest to user</returns>
        /// /// <param name="interestData">for user</param>
        [HttpPost]
        [Route("/add-interest")]
        public async Task<bool> AddInterest(InterestData interestData)
        {
            return await _mediator.Send(new AddInterestToUserCommand(interestData));

        }
        /// <summary>
        /// Sign up user
        /// </summary>
        /// <returns>Registred user or null if user dont exist</returns>
        /// /// <param name="emailAddress">for user</param>
        /// /// <param name="password">for user</param>
        [HttpGet]
        [Route("/sign-up")]
        public async Task<User> SignUpUserAsync(string emailAddress, string password)
        {
            return await _mediator.Send(new SignUpCommand(emailAddress, password));
        }
    }
}

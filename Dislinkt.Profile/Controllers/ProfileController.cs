using Dislinkt.Profile.App.Educations.Commands;
using Dislinkt.Profile.App.Interests.Commands.AddInterestToUser;
using Dislinkt.Profile.App.Interests.Commands.GetAllInterests;
using Dislinkt.Profile.App.Interests.Commands.NewInterest;
using Dislinkt.Profile.App.Interests.Commands.SearchInterests;
using Dislinkt.Profile.App.RegisterUser.Commands;
using Dislinkt.Profile.App.SignUpUser.Commands;
using Dislinkt.Profile.App.Skills.Commands.AddSkillToUser;
using Dislinkt.Profile.App.Skills.Commands.GetAllSkills;
using Dislinkt.Profile.App.Skills.Commands.NewSkills;
using Dislinkt.Profile.App.Skills.Commands.SearchSkills;
using Dislinkt.Profile.App.UpdateUser.Commands;
using Dislinkt.Profile.App.Users.Commands.ApproveUsers;
using Dislinkt.Profile.App.Users.Commands.GetAllUsers;
using Dislinkt.Profile.App.Users.Commands.SearchUsers;
using Dislinkt.Profile.App.Users.Commands.GetUser;
using Dislinkt.Profile.App.Users.Commands.UpdatePrivacy;
using Dislinkt.Profile.App.WorkExperiences;
using Dislinkt.Profile.Application;
using Dislinkt.Profile.Core.MessageProducers;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dislinkt.Profile.App.WorkExperiences.Commands;
using Dislinkt.Profile.App.Users.Commands.GetPublicUsers;

namespace Dislinkt.Profile.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private const string ApiTag = "Profile";
        private readonly IMediator _mediator;
        private readonly IMessageProducer _messageProducer;
        public ProfileController(IMediator mediator, IMessageProducer messageProducer)
        {
            _mediator = mediator;
            _messageProducer = messageProducer;
        }
        /// <summary>
        /// Register new user
        /// </summary>
        /// <returns>A boolean status of registration</returns>
        /// /// <param name="userData">for user</param>
        [HttpPost]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/register-user")]
        public async Task<bool> RegisterUserAsync(UserData userData)
        {
            var result = await _mediator.Send(new RegisterUserCommand(userData));

            if (result == false) return false;

            _messageProducer.SendRegistrationMessage(userData);

            return true;

        }
        /// <summary>
        /// Update existing user
        /// </summary>
        /// <returns>Updated user</returns>
        /// /// <param name="updateUserData">for user</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/update-user")]
        public async Task<User> UpdateUserAsync(UpdateUserData updateUserData)
        {
            return await _mediator.Send(new UpdateUserCommand(updateUserData));

        }
        /// <summary>
        /// Add education
        /// </summary>
        /// <returns>A boolean status of adding education to user</returns>
        /// /// <param name="educationData">for education</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-education")]
        public async Task<bool> AddEducation(EducationData educationData)
        {
            return await _mediator.Send(new EducationCommand(educationData));

        }
        /// <summary>
        /// Update education
        /// </summary>
        /// <returns>Updated educatione</returns>
        /// /// <param name="updateEducation">for user</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/update-education")]
        public async Task UpdateEducationAsync(UpdateEducationData updateEducation)
        {
            await _mediator.Send(new UpdateEducationCommand(updateEducation));

        }

        /// <summary>
        /// Add work experience
        /// </summary>
        /// <returns>A boolean status of adding work experience to user</returns>
        /// /// <param name="workExperienceData">for work experience</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-work-experience")]
        public async Task<bool> AddWorkExperience(WorkExperienceData workExperienceData)
        {
            return await _mediator.Send(new WorkExperienceCommand(workExperienceData));

        }
        /// <summary>
        /// Update work experience
        /// </summary>
        /// <returns>Updated work experience</returns>
        /// /// <param name="updateWorkExperience">for user</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/update-work-experience")]
        public async Task UpdateWorkExperienceAsync(UpdateWorkExperienceData updateWorkExperience)
        {
             await _mediator.Send(new EditWorkExperienceCommand(updateWorkExperience));

        }
        /// <summary>
        /// Add new skill
        /// </summary>
        /// <returns>A boolean status of adding skill to user</returns>
        /// /// <param name="skillAddedData">for skill</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-new-skill/")]
        public async Task<bool> AddNewSkill(SkillAddedData skillAddedData)
        {
            return await _mediator.Send(new NewSkillCommand(skillAddedData));

        }
        /// <summary>
        /// Add existing skill
        /// </summary>
        /// <returns>A boolean status of adding skill to user</returns>
        /// /// <param name="skillData">for skill</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-skill")]
        public async Task<bool> AddSkill(SkillData skillData)
        {
            return await _mediator.Send(new AddSkillToUserCommand(skillData));

        }
        /// <summary>
        /// Add new interest
        /// </summary>
        /// <returns>A boolean status of adding interest to user</returns>
        /// /// <param name="interestAddedData">for interest</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-new-interest")]
        public async Task<bool> AddNewInterest(InterestAddedData interestAddedData)
        {
            return await _mediator.Send(new NewInterestCommand(interestAddedData));

        }
        /// <summary>
        /// Add existing interest
        /// </summary>
        /// <returns>A boolean status of adding interest to user</returns>
        /// /// <param name="interestData">for interest</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-interest")]
        public async Task<bool> AddInterest(InterestData interestData)
        {
            return await _mediator.Send(new AddInterestToUserCommand(interestData));

        }
        /// <summary>
        /// Approve user
        /// </summary>
        /// <returns>A boolean status of approving user</returns>
        /// /// <param name="id">for user</param>
        [HttpPost]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/approve-user/{id}")]
        public async Task<bool> ApproveUserAsync(Guid id)
        {
            return await _mediator.Send(new ApproveUserCommand(id));

        }
        /// <summary>
        /// Change privacy
        /// </summary>
        /// <returns>A boolean status of changed privacy for user</returns>
        /// /// <param name="userId">for user</param>
        /// /// <param name="isPublic">for privacy</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/change-privacy")]
        public async Task<bool> ChangePrivacyAsync(Guid userId, bool isPublic)
        {
            return await _mediator.Send(new UpdatePrivacyCommand(userId, isPublic));

        }
        /// <summary>
        /// Sign up user
        /// </summary>
        /// <returns>Registred user or null if user dont exist</returns>
        /// /// <param name="emailAddress">for user</param>
        /// /// <param name="password">for user</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/sign-up")]
        public async Task<UserDetails> SignUpUserAsync(string emailAddress, string password)
        {
            return await _mediator.Send(new SignUpCommand(emailAddress, password));
        }
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>Get all users</returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/get-all-users")]
        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            return await _mediator.Send(new GetAllUsersCommand());
        }
        /// <summary>
        /// Get public users
        /// </summary>
        /// <returns>Get all users</returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/get-public-users")]
        public async Task<IReadOnlyCollection<User>> GetPublicUsersAsync()
        {
            return await _mediator.Send(new GetPublicUsersCommand());
        }
        /// <summary>
        /// Get user
        /// </summary>
        /// <returns>Get user by id</returns>
        /// /// /// <param id="id">for user</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/get-user")]
        public async Task<User> GetUserAsync(Guid id)
        {
            return await _mediator.Send(new GetUserCommand(id));
        }
        /// <summary>
        /// Search users
        /// </summary>
        /// <returns>Get users by username</returns>
        /// /// /// <param name="username">for user</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/search-users")]
        public async Task<IReadOnlyCollection<User>> SearchUserAsync(string username)
        {
            return await _mediator.Send(new SearchUsersCommand(username));
        }
        /// <summary>
        /// Search skills
        /// </summary>
        /// <returns>Get skills by name</returns>
        /// /// /// <param name="name">for skill</param>
        [HttpGet]
        [Route("/search-skills")]
        public async Task<IReadOnlyCollection<Skill>> SearchSkillsAsync(string name)
        {
            return await _mediator.Send(new SearchSkillsCommand(name));
        }
        /// <summary>
        /// Search interests
        /// </summary>
        /// <returns>Get interests by name</returns>
        /// /// /// <param name="name">for interests</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/search-interests")]
        public async Task<IReadOnlyCollection<Interest>> SearchInterestsAsync(string name)
        {
            return await _mediator.Send(new SearchInterestsCommand(name));
        }
        /// <summary>
        /// Get all skills
        /// </summary>
        /// <returns>Get all skills</returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/get-all-skills")]
        public async Task<IReadOnlyCollection<Skill>> GetAllSkillsAsync()
        {
            return await _mediator.Send(new GetAllSkillsCommand());
        }
        /// <summary>
        /// Get all interests
        /// </summary>
        /// <returns>Get all interests</returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/get-all-interests")]
        public async Task<IReadOnlyCollection<Interest>> GetAllInterestsAsync()
        {
            return await _mediator.Send(new GetAllInterestsCommand());
        }
    }
}

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
using System.Diagnostics;
using System.Threading.Tasks;
using Dislinkt.Profile.App.WorkExperiences.Commands;
using Dislinkt.Profile.App.Users.Commands.GetPublicUsers;
using Dislinkt.Profile.App.Skills.Commands.GetUserSkills.Commands;
using Dislinkt.Profile.App.Interests.Commands.GetUserInterests;
using Dislinkt.Profile.App.Interests.Commands.RemoveInterestFromUser;
using Dislinkt.Profile.App.Skills.RemoveSkillFromUser.Commands;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using Dislinkt.Profile.Core.Repositories;
using System.Security.Cryptography;
using GrpcNotificationService;
using OpenTracing;
using GrpcAddActivityService;
using GrpcAddUserJobsService;
using Dislinkt.Profile.App.Users.Commands.DeleteUser;
//using Dislinkt.Profile.WebApi.Protos;
using GrpcAddSkillService;
using Greeter = GrpcService.Greeter;

namespace Dislinkt.Profile.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private const string ApiTag = "Profile";
        private readonly IMediator _mediator;
        private readonly IMessageProducer _messageProducer;
        private IOptions<Audience> _settings;
        private readonly IUserRepository _userRepository;
        private readonly ITracer _tracer;
        public ProfileController(IMediator mediator, IUserRepository userRepository, IMessageProducer messageProducer, IOptions<Audience> settings, ITracer tracer)
        {
            _mediator = mediator;
            _messageProducer = messageProducer;
            this._settings = settings;
            _userRepository = userRepository;
            _tracer = tracer;

        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <returns>A boolean status of registration</returns>
        /// /// <param name="userData">for user</param>
        [HttpPost]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/register-user")]
        public async Task<User> RegisterUserAsync(UserData userData)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);

            var result = await _mediator.Send(new RegisterUserCommand(userData));

            if (result == null) return null;

            //_messageProducer.SendRegistrationMessage(userData);

            /* var channel = GrpcChannel.ForAddress("https://localhost:5001/");
             var client = new Greeter.GreeterClient(channel);

             var reply = client.SayHello(new HelloRequest { Id = result.Id.ToString(), Username = userData.Username, Status = 1 });

             if (!reply.Successful)
             {
                 Debug.WriteLine("Doslo je do greske prilikom upisa u Neo4j (Connections)");
                 return null;
             }

             Debug.WriteLine("Successfully passed on for registration to Neo4j (Connections) -- " + reply.Message);*/

            /*var channel2 = GrpcChannel.ForAddress("https://localhost:5002/");
            var client2 = new notificationSettingsGreeter.notificationSettingsGreeterClient(channel2);

            var reply2 = client2.CreateSettings(new NotificationSettingsRequest { UserId = result.Id.ToString(), MessageOn=true,PostOn=true,JobOn=true,FriendRequestOn=true});
           
            if (!reply2.Successful)
            {
                Debug.WriteLine("Doslo je do greske prilikom kreiranja notifikacija za usera");
                return null;
            }
            
            Debug.WriteLine("Successfully passed on for registration to notifications -- " + reply2.Message);*/

            /*var channel3 = GrpcChannel.ForAddress("https://localhost:5003/");
            var client3 = new addActivityGreeter.addActivityGreeterClient(channel3);
            var reply3 = client3.addActivity(new ActivityRequest { UserId = result.Id.ToString(), Text = "Sucessfully registered", Type = "Registration", Date = DateTime.Now.ToString() });

            if (!reply3.Successful)
            {
                Debug.WriteLine("Doslo je do greske prilikom kreiranja eventa za admina");
                return null;
            }

            Debug.WriteLine("Uspesno prosledjen na dashboard kod admina-- " + reply3.Message);*/


            /*var channel4 = GrpcChannel.ForAddress("https://localhost:5004/"); // podesiti kanal lokalno
            var client4 = new AddUserJobsGreeter.AddUserJobsGreeterClient(channel4);

            var reply4 = client4.AddUserJobs(new AddUserJobsRequest { Id = result.Id.ToString(), Name = userData.Username, Seniority = (int)result.Seniority});

            if (!reply4.Successful)
            {
                Debug.WriteLine("Doslo je do greske prilikom upisa u Neo4j (Jobs)");
                return null;
            }

            Debug.WriteLine("Successfully passed on for registration to Neo4j (Jobs) -- " + reply4.Message);*/

            return result;
        }
        /// <summary>
        /// Delete existing user
        /// </summary>
        /// <returns>user</returns>
        [HttpDelete]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/delete-user/{id}")]
        public async Task RemoveProduct(Guid id)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            await _mediator.Send(new DeleteUserCommand(id));
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <returns>Updated user</returns>
        /// /// <param name="updateUserData">for user</param>
        [HttpPut]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/user")]
        public async Task<User> UpdateUserAsync(UpdateUserData updateUserData)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);

            if (updateUserData.SeniorityUpdated)
            {
                var channel = GrpcChannel.ForAddress("https://localhost:5004/"); // podesiti kanal lokalno
                var client = new UpdateSeniorityGreeter.AddUserJobsGreeterClient(channel);

                var reply = client.AddUserJobs(new AddUserJobsRequest { Id = updateUserData.Id.ToString(), Seniority = (int)updateUserData.Seniority});

                if (!reply.Successful)
                {
                    Debug.WriteLine("Doslo je do greske prilikom izmene u Neo4j (Jobs)");
                    return null;
                }

                Debug.WriteLine("Successfully passed on for seniority update to Neo4j (Jobs) -- " + reply.Message);

            }

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
        [Route("/education")]
        public async Task<bool> AddEducation(EducationData educationData)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new EducationCommand(educationData));

        }
        /// <summary>
        /// Update education
        /// </summary>
        /// <returns>Updated educatione</returns>
        /// /// <param name="updateEducation">for user</param>
        [HttpPut]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/education")]
        public async Task UpdateEducationAsync(UpdateEducationData updateEducation)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
        [Route("/work-experience")]
        public async Task<bool> AddWorkExperience(WorkExperienceData workExperienceData)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new WorkExperienceCommand(workExperienceData));

        }
        /// <summary>
        /// Update work experience
        /// </summary>
        /// <returns>Updated work experience</returns>
        /// /// <param name="updateWorkExperience">for user</param>
        [HttpPut]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/work-experience")]
        public async Task UpdateWorkExperienceAsync(UpdateWorkExperienceData updateWorkExperience)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
        [Route("/add-new-skill")]
        public async Task<Skill> AddNewSkill(SkillAddedData skillAddedData)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);

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
        [Route("/skill")]
        public async Task<bool> AddSkill(SkillData skillData)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            /*var channel = GrpcChannel.ForAddress("https://localhost:5004"); // podesiti kanal lokalno
            var client = new AddSkillGreeter.AddSkillGreeterClient(channel);

            var reply = client.AddSkill(new AddSkillRequest { UserId = skillData.UserId.ToString(), SkillId = skillData.Id.ToString()});

            if (!reply.Successful)
            {
                Debug.WriteLine("Doslo je do greske prilikom upisa u Neo4j (Jobs)");
                return false;
            }

            Debug.WriteLine("Successfully passed skill on for registration to Neo4j (Jobs) -- " + reply.Message);*/

            
            return await _mediator.Send(new AddSkillToUserCommand(skillData));

        }
        /// <summary>
        /// Add existing interest
        /// </summary>
        /// <returns>A boolean status of removing skill from user</returns>
        /// /// <param name="userId">for user</param>
        /// /// <param name="skillId">for interest</param>
        [HttpDelete]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/skill")]
        public async Task<bool> RemoveSkill(Guid userId, Guid skillId)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new RemoveSkillFromUserCommand(userId, skillId));

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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
        [Route("/interest")]
        public async Task<bool> AddInterest(InterestData interestData)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new AddInterestToUserCommand(interestData));

        }
        /// <summary>
        /// Add existing interest
        /// </summary>
        /// <returns>A boolean status of removing interest from user</returns>
        /// /// <param name="userId">for user</param>
        /// /// <param name="interestId">for interest</param>
        [HttpDelete]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/interest")]
        public async Task<bool> RemoveInterest(Guid userId, Guid interestId)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new RemoveInterestFromUserCommand(userId, interestId));

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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new ApproveUserCommand(id));

        }
        /// <summary>
        /// Change privacy
        /// </summary>
        /// <returns>A boolean status of changed privacy for user</returns>
        /// /// <param name="userId">for user</param>
        /// /// <param name="isPublic">for privacy</param>
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/change-privacy")]
        public async Task<bool> ChangePrivacyAsync(Guid userId, bool isPublic)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new UpdatePrivacyCommand(userId, isPublic));

        }
        /// <summary>
        /// Sign up user
        /// </summary>
        /// <returns>Registred user or null if user dont exist</returns>
        /// /// <param name="username">for user</param>
        /// /// <param name="password">for user</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/sign-up")]
        public IActionResult SignUpUserAsync(string username, string password)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            //return await _mediator.Send(new SignUpCommand(username, password));
            var userDetails = _userRepository.GetUserByUsernameAndPasswordAsync(username, BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(password))));

            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.Value.Secret));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = _settings.Value.Iss,
                ValidateAudience = true,
                ValidAudience = _settings.Value.Aud,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,

            };

            var jwt = new JwtSecurityToken(
                issuer: _settings.Value.Iss,
                audience: _settings.Value.Aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var responseJson = new
            {
                user = userDetails.Result,
                access_token = encodedJwt,
                expires_in = (int)TimeSpan.FromMinutes(30).TotalSeconds
            };

            return Ok(responseJson);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new GetPublicUsersCommand());
        }
        /// <summary>
        /// Get user
        /// </summary>
        /// <returns>Get user by id</returns>
        /// /// /// <param id="id">for user</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/user")]
        public async Task<User> GetUserAsync(Guid id)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new GetAllInterestsCommand());
        }
        /// <summary>
        /// Get user skills
        /// </summary>
        /// <returns>Get user skills</returns>
        /// /// /// /// <param id="id">for user</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/get-user-skills")]
        public async Task<IReadOnlyCollection<Skill>> GetUserSkillsAsync(Guid id)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new GetUserSkillsCommand(id));
        }
        /// <summary>
        /// Get user interests
        /// </summary>
        /// <returns>Get user interests</returns>
        /// /// /// /// <param id="id">for user</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/get-user-interests")]
        public async Task<IReadOnlyCollection<Interest>> GetUserInterestsAsync(Guid id)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new GetUserInterestsCommand(id));
        }
    }

    public class Audience
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
    }
}

using Dislinkt.Profile.App.RegisterUser.Commands;
using Dislinkt.Profile.App.SignUpUser.Commands;
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
        public async Task<bool> RegisterUserAsync(UserData userData)
        {
            return await _mediator.Send(new RegisterUserCommand(userData));

        }
        /// <summary>
        /// Sign up user
        /// </summary>
        /// <returns>Registred user or null if user dont exist</returns>
        /// /// <param name="emailAddress">for user</param>
        /// /// <param name="password">for user</param>
        [HttpGet]
        public async Task<User> SignUpUserAsync(string emailAddress, string password)
        {
            return await _mediator.Send(new SignUpCommand(emailAddress, password));
        }
    }
}

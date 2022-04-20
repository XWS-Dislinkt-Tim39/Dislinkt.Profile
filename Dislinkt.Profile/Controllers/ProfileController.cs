using Dislinkt.Profile.App.RegisterUser.Commands;
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
    }
}

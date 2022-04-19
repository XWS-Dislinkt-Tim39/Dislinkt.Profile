using Dislinkt.Profile.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dislinkt.Profile.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        /// <summary>
        /// Register new user
        /// </summary>
        /// <returns>A boolean status of registration</returns>
        [HttpPost]
        public bool RegisterUser(UserData userData)
        {
            return false;
        }
    }
}

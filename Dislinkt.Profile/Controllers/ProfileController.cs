using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public bool RegisterUser()
        {
            return false;
        }
    }
}

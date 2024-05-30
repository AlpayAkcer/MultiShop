using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multishop.IdentityServer.Models;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Multishop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public StatisticsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet("GetUserCount")]
        public IActionResult GetUserCount()
        {
            var userCount = _userManager.Users.Count();
            return Ok(userCount);
        }
    }
}

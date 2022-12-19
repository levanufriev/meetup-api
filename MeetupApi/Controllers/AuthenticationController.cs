using AutoMapper;
using Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeetupApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> logger;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAuthenticationManager authenticationManager;

        public AuthenticationController(ILogger<AuthenticationController> logger, IMapper mapper,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            IAuthenticationManager authenticationManager)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.authenticationManager = authenticationManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null)
            {
                logger.LogError("userForRegistration is null");
                return BadRequest("userForRegistration is null");
            }

            foreach (var role in userForRegistration.Roles)
            {
                if (!(await roleManager.RoleExistsAsync(role)))
                {
                    logger.LogError($"role {role} doesn't exist in database");
                    return BadRequest($"role {role} doesn't exist in database");
                }
            }

            var user = mapper.Map<User>(userForRegistration);

            var result = await userManager.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (user == null)
            {
                logger.LogError("UserForAuthentication is null");
                return BadRequest("UserForAuthentication is null");
            }

            if (!(await authenticationManager.ValidateUser(user)))
            {
                logger.LogError($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }

            return Ok(new { Token = await authenticationManager.CreateToken() });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Business.Extension;
using TwitterClone.Business.IRepositories;
using TwitterClone.Business.IServices;
using TwitterClone.Business.Models;
using TwitterClone.Server.API.Controllers.DTO;

namespace TwitterClone.Server.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;

        public AuthController(IConfiguration config, ITokenService tokenService, IUserRepository userRepository)
        {
            this.config = config;
            this.tokenService = tokenService;
            this.userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserInput user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                return BadRequest("No login or password");

            var validUser = await userRepository.GetByEmailAsync(user.Email);

            if (validUser == null)
                return BadRequest("This email not registred"); 

            if (!tokenService.ComparePasswords(user.Password, validUser.Password, validUser.Salt))
                return BadRequest("Incorrect password");

            string generatedToken = tokenService.BuildToken(config["JWT:SecretKey"].ToString(), validUser);

            if (generatedToken == null)
                return BadRequest();

            return Ok(generatedToken);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister user)
        {
            var model = user.ToUserModel();

            if (!tokenService.ValidateUser(model))
                return BadRequest();

            var validUser = await userRepository.GetByEmailAsync(model.Email);

            if (validUser != null)
                return BadRequest("This email already registred");

            await userRepository.CreateAsync(model);
            
            return Ok();
        }
    }

}

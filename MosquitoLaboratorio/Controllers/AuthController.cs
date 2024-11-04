using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Services.Auth;
using MosquitoLaboratorio.Utils;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost, Route("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginDTO dTO)
        {
            var auth = await _authService.Authenticate(dTO);
            if (auth == null)
                return BadRequest();
            var jwtManager = new JwtManager();
            string jwt = jwtManager.GenerateJwtToken(auth.UserId, auth.UserName!, auth.Role!, _configuration);
            return Ok(new { jwt = jwt, info = auth.AditionalInfo, status = auth.Status, firstLogin = auth.FirstLogin });
        }

        [HttpPost, Route("ChangePassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordDTO changePasswordDTO)
        {
            var success = await _authService.ChangePassword(changePasswordDTO);
            if (success)
                return Ok();
            return BadRequest();
        }
    }
}

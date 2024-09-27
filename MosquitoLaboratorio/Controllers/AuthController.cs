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
        public async Task<IActionResult> Authenticate([FromBody] UserDTO dTO)
        {
            var auth = await _authService.Authenticate(dTO.UserName!, dTO.Password!);
            if (auth == null)
                return BadRequest();
            string jwt = JwtManager.GenerateJwtToken(auth.UserName!, auth.Password!, _configuration);
            return Ok(new {jwt = jwt, user = auth});
        }
    }
}

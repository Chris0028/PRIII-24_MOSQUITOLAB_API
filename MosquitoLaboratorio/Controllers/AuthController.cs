using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Services.Auth;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost, Route("SignIn")]
        public async Task<IActionResult> Authenticate([FromBody] UserDTO dTO)
        {
            var auth = await _authService.Authenticate(dTO.UserName!, dTO.Password!);
            if (auth == null)
                return BadRequest();
            return Ok(auth);
        }
    }
}

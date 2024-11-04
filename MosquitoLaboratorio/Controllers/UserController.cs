using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Services.User;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpGet, Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync(int page = 1, int limit = 5)
        {
            var users = await _userService.GetAll(page, limit);
            return Ok(new { data = users.Item1, total = users.Item2 });
        }

        [HttpPost, Route("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromBody]int userId)
        {
            var userDeleted = await _userService.Delete(userId);
            if (userDeleted > 0)
                return NoContent();
            return BadRequest();
        }

        [HttpPost, Route("New")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> New([FromBody]NewUserDTO userDTO)
        {
            var rowsAffected = await _userService.New(userDTO);
            if(rowsAffected > 0)
                return CreatedAtAction(nameof(New), 
                    new {name = userDTO.Name, 
                        lastName = userDTO.LastName, 
                        secondLastName = userDTO.SecondLastName, 
                        role = userDTO.Role});
            return BadRequest();
        }

        [HttpPost, Route("ChangeFirstLogin")]
        public async Task<IActionResult> ChangeFirstLogin([FromBody]string username)
        {
            var success = await _userService.ChangeFirstLoginValue(username);
            if (success > 0)
                return NoContent();
            return BadRequest();
        }

        [HttpGet, Route("GetProfile")]
        [Authorize]
        public async Task<IActionResult> GetProfile(int id, string role)
        {
            if(role != "Doctor")
            {
                var getEmployeeOrAdminProfile = await _userService.GetProfileEmployeeOrAdmin(id);
                return Ok(getEmployeeOrAdminProfile);
            }
            else
            {
                var getDoctorProfile = await _userService.GetProfileDoctor(id);
                return Ok(getDoctorProfile);
            }
        }

        [HttpPatch, Route("UpdateProfile/{id::int}")]
        public async Task<IActionResult> UpdateProfile([FromRoute]int id, [FromBody]ProfileDTO profile)
        {
            profile.UserId = id;
            var response = await _userService.Update(profile);
            if (response > 0)
                return NoContent();
            return BadRequest();
        }
    }
}

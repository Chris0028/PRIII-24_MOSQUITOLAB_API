using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Services.Hospital;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService) => _hospitalService = hospitalService;

        [HttpGet, Route("GetHospitals")]
        [Authorize]
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await _hospitalService.GetHospitals();
            if(hospitals is not null)
                return Ok(hospitals);

            return NotFound();
        }

        [HttpGet, Route("GetNamesNIds")]
        [Authorize]
        public async Task<IActionResult> GetNamesNIdsOfHospitals()
        {
            var hospitals = await _hospitalService.GetNamesNIds();
            return Ok(hospitals);
        }
    }
}

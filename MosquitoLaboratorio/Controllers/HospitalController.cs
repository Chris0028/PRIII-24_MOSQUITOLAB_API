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
        public async Task<IActionResult> GetHospitals()
        {
            var hospitals = await _hospitalService.GetHospitals();
            if(hospitals is not null)
                return Ok(hospitals);

            return NotFound();
        }
    }
}

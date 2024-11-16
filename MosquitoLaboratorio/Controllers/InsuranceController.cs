using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Services.Insurance;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService) => _insuranceService = insuranceService;

        [HttpGet, Route("GetInsurances")]
        [Authorize]
        public async Task<ActionResult> GetInsurances()
        {
            var insurances = await _insuranceService.GetInsurances();

            if(insurances is not null)
                return Ok(insurances);

            return NotFound();
        }
    }
}

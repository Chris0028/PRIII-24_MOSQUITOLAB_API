using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Services.Sample;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService) => _sampleService = sampleService;

        [HttpGet, Route("All")]
        public async Task<IActionResult> GetSamples()
        {
            var samples = await _sampleService.GetSamples();
            if(samples != null)
                return Ok(samples);
            return BadRequest();
        }

        [HttpGet, Route("GetDiseases")]
        public async Task<IActionResult> GetDiseases()
        {
            var diseases = await _sampleService.GetDiseases();
            if (diseases != null)
                return Ok(diseases);
            return BadRequest();
        }
    }
}

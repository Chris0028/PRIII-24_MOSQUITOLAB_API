using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Services.Sample;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService) => _sampleService = sampleService;

        [HttpPost, Route("All")]
        public async Task<IActionResult> GetSamples([FromBody]SampleDTO? sampleDTO)
        {
            var samples = await _sampleService.GetSamples(sampleDTO);
            if(samples != null)
                return Ok(samples);
            return Ok("Sin registros");
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

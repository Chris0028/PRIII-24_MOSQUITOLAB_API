using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Dtos.Test;
using MosquitoLaboratorio.Services.Test;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService) => _testService = testService;

        [HttpPatch, Route("UpdateTestSample")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> UpdateTestSample([FromBody] UpdateTestSampleDTO dto)
        {
            var data = await _testService.UpdateTestSample(dto);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet, Route("GetTestSample/{fileId::long}")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetTestSample([FromRoute]long fileId)
        {
            var getTestSample = await _testService.GetTestSample(fileId);
            if (getTestSample == null)
                return BadRequest("No data found");
            return Ok(getTestSample);
        }
    }
}

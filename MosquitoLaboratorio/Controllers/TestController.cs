using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Dtos.Test;
using MosquitoLaboratorio.Services.Laboratory;
using MosquitoLaboratorio.Services.Test;

namespace MosquitoLaboratorio.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService) => _testService = testService;

        [HttpPatch, Route("UpdateTestSample")]
        public async Task<IActionResult> UpdateTestSample(long fileID, [FromBody] UpdateTestSampleDTO dto)
        {
            var laboratories = await _testService.UpdateTestSample(fileID, dto);
            if (laboratories == null)
                return NotFound();

            return Ok(laboratories);
        }
    }
}

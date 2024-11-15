using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Services.Result;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;

        public ResultController(IResultService result) => _resultService = result;

        [HttpPost, Route("GetResult")]
        public async Task<IActionResult> GetResult([FromBody]long id)
        {
            var result = await _resultService.GetResultById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}

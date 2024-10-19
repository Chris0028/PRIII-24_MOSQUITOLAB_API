using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Services.Laboratory;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService _laboratoryService;

        public LaboratoryController(ILaboratoryService laboratoryService) => _laboratoryService = laboratoryService;

        [HttpGet, Route("GetLaboratories")]
        public async Task<IActionResult> GetLaboratories()
        {
            var laboratories = await _laboratoryService.GetLaboratories();
            if (laboratories == null)
                return NotFound();

            return Ok(laboratories);
        }
    }
}

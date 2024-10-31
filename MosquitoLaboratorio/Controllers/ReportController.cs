using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Services.Reports;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService) => _reportService = reportService;

        [HttpGet, Route("ReportByGender")]
        public async Task<IActionResult> ReportByGender()
        {
            var patients = await _reportService.ReportPatientByGender();
            if(patients == null)
                return NotFound();

            return Ok(patients);
        }

        [HttpGet, Route("ReportByAge")]
        public async Task<IActionResult> ReportByAge()
        {
            var patients = await _reportService.ReportPatientByAge();
            if (patients == null)
                return NotFound();

            return Ok(patients);
        }
    }
}

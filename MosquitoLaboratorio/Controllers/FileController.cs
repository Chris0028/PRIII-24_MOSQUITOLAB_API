using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MosquitoLaboratorio.Dtos.File;
using MosquitoLaboratorio.Services.Auth;
using MosquitoLaboratorio.Services.File;
using MosquitoLaboratorio.Services.Hub;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public FileController(IHubContext<NotificationHub> hubContext, IFileService fileService)
        {
            _hubContext = hubContext;
            _fileService = fileService;
        }

        [HttpPost, Route("CreateFile")]
        public async Task<IActionResult> CreateFile(CreateFileDTO dTO)
        {
            var file = await _fileService.CreateFile(dTO);
            if (file != 0)
            {
                await _hubContext.Clients.Group(dTO.TestLaboratoryId.ToString())
                                     .SendAsync("ReceiveNotification", "Nueva ficha a la espera de revision");
                return StatusCode(201, file);
            }
            return BadRequest();
        }

        [HttpPatch, Route("UpdateFile")]
        public async Task<IActionResult> UpdateFile([FromBody] UpdateFileDTO dTO)
        {
            var file = await _fileService.UpdateFile(dTO);
            if (file != 0)
            {
                return StatusCode(200, file);
            }
            return BadRequest();
        }

        [HttpPost, Route("HistoryFileByHospital")]
        [Authorize]
        public async Task<IActionResult> GetHistoryByHospitalId([FromBody] long? hospitalID)
        {
            if (hospitalID.HasValue)
            {
                var files = await _fileService.GetHistoryByHospitalId(hospitalID!.Value);
                return Ok(files);
            }
            else
            {
                var files = await _fileService.GetAllHistory();
                return Ok(files);
            }
        }

        [HttpPost, Route("GetHistoryForLab")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetHistoryForLab([FromBody] int? laboratoryID)
        {
            if(laboratoryID.HasValue)
            {
                var files = await _fileService.GetHistoryByLabId(laboratoryID.Value);
                return Ok(files);
            }
            else
            {
                var files = await _fileService.GetAllHistory();
                return Ok(files);
            }
        }
        [HttpPost, Route("GetReportsList")]
        public async Task<IActionResult> GetReportFileList([FromBody] ReportFileParametersDTO dto)
        {
            var reports = await _fileService.GetReportFileList(dto);
            if (reports is not null)
            {
                return Ok(reports);
            }
            return NoContent();
        }
    }
}

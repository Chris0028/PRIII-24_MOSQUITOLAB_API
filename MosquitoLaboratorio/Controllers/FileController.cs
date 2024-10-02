using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MosquitoLaboratorio.Dtos;
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
        public async Task<IActionResult> CreateFile([FromBody] CreateFileDTO dTO)
        {
            var file = await _fileService.CreateFile(dTO);
            if (file != 0)
            {
                await _hubContext.Clients.Group(dTO.LaboratoryId.ToString())
                                     .SendAsync("ReceiveNotification", "Nueva ficha a la espera de revision");
                return Ok(file);
            }
            return BadRequest();
        }

        [HttpPost, Route("HistoryFileByHospital")]
        public async Task<IActionResult> GetHistoryByHospitalId(long hospitalID)
        {
            var files = await _fileService.GetHistoryByHospitalId(hospitalID);
            if (files is not null)
                return Ok(files);
            return BadRequest("No history files found for this Hospital");
        }

        [HttpGet, Route("HistoryFileByLaboratory")]
        public async Task<IActionResult> GetHistoryForLab()
        {
            var files = await _fileService.GetHistoryForLab();
            if (files is not null)
                return Ok(files);
            return BadRequest("No history files found for this Laboratory");
        }
    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Dtos.File;
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
        [Authorize]
        public async Task<IActionResult> CreateFile(CreateFileDTO dTO)
        {
            var file = await _fileService.CreateFile(dTO);

            if (file == 10)
            {
                return BadRequest("No se puede crear una nueva ficha: existe una ficha pendiente para esta enfermedad.");
            }

            if (file == -1)
            {
                await _hubContext.Clients.Group(dTO.TestLaboratoryId.ToString())
                                         .SendAsync("ReceiveNotification", "Nueva ficha a la espera de revisión");
                return StatusCode(201, file);
            }

            return BadRequest("No se pudo crear la ficha debido a un error inesperado.");
        }


        [HttpPatch, Route("UpdateFile")]
        [Authorize(Roles = "Admin,Employee")]
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
        public async Task<IActionResult> GetHistoryByHospitalId([FromBody] long? hospitalID, int page = 1, int limit = 10)
        {
            if (hospitalID.HasValue)
            {
                var files = await _fileService.GetHistoryByHospitalId(hospitalID.Value, page, limit);
                return Ok(new { data = files.Item1, total = files.Item2 });
            }
            else
            {
                var files = await _fileService.GetAllHistory(page, limit);
                return Ok(new { data = files.Item1, total = files.Item2 });
            }
        }

        [HttpPost, Route("HistoryForLab")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetHistoryForLab([FromBody] int? laboratoryID, int page = 1, int limit = 10)
        {
            if (laboratoryID.HasValue)
            {
                var files = await _fileService.GetHistoryByLabId(laboratoryID.Value, page, limit);
                return Ok(new { data = files.Item1, total = files.Item2 });
            }
            else
            {
                var files = await _fileService.GetAllHistory(page, limit);
                return Ok(new { data = files.Item1, total = files.Item2 });
            }
        }


        [HttpPost, Route("GetFileDetails")]
        public async Task<IActionResult> GetFileDetails([FromBody] long fileID)
        {
            var files = await _fileService.GetFileDetails(fileID);
            if (files is not null)
                return Ok(files);
            return BadRequest("Not data found");
        }

        [HttpPost, Route("GetReportsList")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetReportFileList([FromBody] ReportFileParametersDTO dto)
        {
            var reports = await _fileService.GetReportFileList(dto);
            if (reports is not null)
            {
                return Ok(reports);
            }
            return NoContent();

        }

        [HttpPost, Route("HistoryFilterByHospitalId")]
        [Authorize]
        public async Task<IActionResult> HistoryFilterByHospitalId([FromBody] HistoryFileFilterDTO? filterDTO)
        {
            var fileH = await _fileService.HistoryFilterByHospitalId(filterDTO);
            if (fileH is not null)
                return Ok(fileH);
            return BadRequest("Not data found");
        }

        [HttpPost, Route("HistoryFilterByLabId")]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> HistoryFilterByLabId([FromBody] HistoryFileFilterDTO? filterDTO)
        {
            var fileL = await _fileService.HistoryFilterByLabId(filterDTO);
            if (fileL is not null)
                return Ok(fileL);
            return BadRequest("Not data found");
        }

        [HttpPost, Route("GetFileWithResult")]
        [Authorize]
        public async Task<IActionResult> GetFileWithResultAsync([FromBody]long fileId)
        {
            var fileSerialize = await _fileService.GetFileWithResult(fileId);
            if (fileSerialize != null)
                return Ok(fileSerialize);
            return BadRequest();
        }

        
    }
}

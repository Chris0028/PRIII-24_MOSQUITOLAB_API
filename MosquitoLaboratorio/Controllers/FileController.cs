using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Dtos;
using MosquitoLaboratorio.Services.Auth;
using MosquitoLaboratorio.Services.File;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController (IFileService fileService) => _fileService = fileService;

        [HttpPost, Route("CreateFile")]
        public async Task<IActionResult> CreateFile([FromBody] CreateFileDTO dTO)
        {
            var file = await _fileService.CreateFile(dTO);
            if (file == 0)
                return BadRequest();
            return Ok(file);
        }
    }
}

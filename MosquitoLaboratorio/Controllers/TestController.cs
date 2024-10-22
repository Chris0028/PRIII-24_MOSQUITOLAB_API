﻿using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Dtos.Test;
using MosquitoLaboratorio.Services.Laboratory;
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
        public async Task<IActionResult> UpdateTestSample([FromBody] UpdateTestSampleDTO dto)
        {
            var data = await _testService.UpdateTestSample(dto);
            if (data == null)
                return NotFound();

            return Ok(data);
        }
    }
}
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosquitoLaboratorio.Services.Location;

namespace MosquitoLaboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService) => _locationService = locationService;

        [HttpGet, Route("GetMunicipalities")]
        [Authorize]
        public async Task<IActionResult> GetMunicipalities()
        {
            var municipalities = await _locationService.GetMunicipality();
            if(municipalities == null)
                return NotFound();

            return Ok(municipalities);
        }

        [HttpGet, Route("GetStates")]
        [Authorize]
        public async Task<IActionResult> GetStates()
        {
            var states = await _locationService.GetStates();
            if(states == null)
                return NotFound();

            return Ok(states);
        }
    }
}   

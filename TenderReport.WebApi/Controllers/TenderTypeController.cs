using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderReport.Core.Models;
using TenderReport.Core.Services;

namespace TenderReport.WebApi.Controllers
{
    [Route("api/TenderType")]
    [ApiController]
    public class TenderTypeController : ControllerBase
    {
        private readonly ITenderTypeService _tenderTypeService;

        public TenderTypeController(ITenderTypeService tenderTypeService)
        {
            _tenderTypeService = tenderTypeService;
        }
        // GET: api/TenderType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodesViewDTO>>> Get()
        {
            return Ok( await _tenderTypeService.GetAllTenders());
        }

        // POST: api/TenderType
        [HttpPost]
        public async Task<IActionResult> CreateTender([FromBody] CodesCreateDTO tendersCreateDTO)
        {
            if (await _tenderTypeService.TenderExists(tendersCreateDTO.Code))
                return BadRequest(tendersCreateDTO.Code + " already exists try with another name");
            
            await _tenderTypeService.CreateTender(tendersCreateDTO);
            return StatusCode(201);
        }

        // PUT: api/TenderType/5
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateTender(string code, [FromBody] CodesCreateDTO tendersCreateDTO)
        {
            await _tenderTypeService.UpdateTender(code, tendersCreateDTO);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteTender(string code)
        {
            await _tenderTypeService.DeleteTender(code);
            return NoContent();
        }
    }
}

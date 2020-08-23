using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderReport.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderReport.Core.Models;

namespace TenderReport.WebApi.Controllers
{
    [Route("api/expenditure")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureTypeService _ExpenditureTypeService;

        public ExpenditureController(IExpenditureTypeService ExpenditureTypeService)
        {
            _ExpenditureTypeService = ExpenditureTypeService;
        }
        // GET: api/ExpenditureType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodesViewDTO>>> Get()
        {
            return Ok(await _ExpenditureTypeService.GetAllExpenditures());
        }

        // POST: api/ExpenditureType
        [HttpPost]
        public async Task<IActionResult> CreateExpenditure([FromBody] CodesCreateDTO ExpendituresCreateDTO)
        {
            await _ExpenditureTypeService.CreateExpenditure(ExpendituresCreateDTO);
            return StatusCode(201);
        }

        // PUT: api/ExpenditureType/5
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateExpenditure(string code, [FromBody] CodesCreateDTO ExpendituresCreateDTO)
        {
            await _ExpenditureTypeService.UpdateExpenditure(code, ExpendituresCreateDTO);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteExpenditure(string code)
        {
            await _ExpenditureTypeService.DeleteExpenditure(code);
            return NoContent();
        }
    }
}

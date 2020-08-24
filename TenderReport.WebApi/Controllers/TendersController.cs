using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderReport.Core.Models;
using TenderReport.Core.Services;
using TenderReport.Data.Entities;

namespace TenderReport.WebApi.Controllers
{
    [Route("api/tenders")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        private readonly ITenderService _tenderService;

        public TendersController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }
        // GET: api/Tenders
        [HttpGet("{tenderType}")]
        public async Task<ActionResult<ReportView>> GetAllTenderReports(string tenderType)
        {
            return Ok(await _tenderService.GetAllTenderReports(tenderType));
        }

        [HttpGet("{tenderType}/split")]
        public async Task<ActionResult<SplitReports>> GetSplitTenderReports(string tenderType)
        {
            return Ok(await _tenderService.GetSplitTenderReports(tenderType));
        }
        // POST: api/Tenders
        [HttpPost]
        public async Task<IActionResult> CreateTenderReport([FromBody] ReportCreateDTO reportCreateDTO)
        {
            await _tenderService.CreateTenderReport(reportCreateDTO);
            return StatusCode(201);
        }

        // PUT: api/Tenders/5
        [HttpPut("{tenderReportId}")]
        public async Task<IActionResult> UpdateTenderReport(Guid tenderReportId, [FromBody] ReportCreateDTO reportCreateDTO)
        {
            await _tenderService.UpdateTenderReport(tenderReportId,reportCreateDTO);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{tenderReportId}")]
        public async Task<IActionResult> DeleteTenderReport(Guid tenderReportId)
        {
            await _tenderService.DeleteTenderReport(tenderReportId);
            return NoContent();
        }

        [HttpGet("{tenderType}/overall")]
        public async Task<ActionResult<OverallDTO>> GetOverallTenderReports(string tenderType)
        {
            return Ok(await _tenderService.GetOverallTenderReports(tenderType));
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Core.Models;

namespace TenderReport.Core.Services
{
    public interface ITenderService
    {
        Task<ReportView> GetAllTenderReports(string tenderType);
        Task CreateTenderReport(ReportCreateDTO reportCreateDTO);
        Task UpdateTenderReport(Guid templateReportId, ReportCreateDTO reportCreateDTO);
        Task DeleteTenderReport(Guid templateReportId);
        Task<SplitReports> GetSplitTenderReports(string tenderType);
        Task<OverallDTO> GetOverallTenderReports(string tenderType);
    }
}

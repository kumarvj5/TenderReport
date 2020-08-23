using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Data.Entities;

namespace TenderReport.Data.Repositories
{
    public interface ITenderRepository
    {
        Task<List<Entities.TenderReport>> GetAllTenderReports(string tenderType);
        Task<List<TenderType>> GetTende(string tenderType);
        Task CreateTenderReport(Entities.TenderReport tenderReport);
        Task UpdateTenderReport(Guid templateReportId, Entities.TenderReport tenderReport);
        Task DeleteTenderReport(Guid templateReportId);
    }
}

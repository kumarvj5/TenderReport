using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Data.Entities;

namespace TenderReport.Data.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private readonly TendersContext _context;

        public TenderRepository(TendersContext context)
        {
            _context = context;
        }
        public async Task CreateTenderReport(Entities.TenderReport tenderReport)
        {
            _context.TenderReport.Add(tenderReport);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTenderReport(Guid templateReportId)
        {
            var tenderReportFromDB = await _context.TenderReport.FirstOrDefaultAsync(c => c.TenderReportId == templateReportId);
            tenderReportFromDB.IsDeleted = true;
            _context.Entry(tenderReportFromDB).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Entities.TenderReport>> GetAllTenderReports(string tenderType)
        {
            return await _context.TenderReport.Where(c => c.IsDeleted != true && c.Tendertype.Equals(tenderType)).ToListAsync();
        }

        public async Task<List<TenderType>> GetTende(string tenderType)
        {
            return await _context.TenderType.Where(c => c.Code.Equals(tenderType)).ToListAsync();
        }

        public async Task UpdateTenderReport(Guid templateReportId, Entities.TenderReport tenderReport)
        {
            var tenderReportFromDB = await _context.TenderReport.FirstOrDefaultAsync(c => c.TenderReportId == templateReportId);
            tenderReport.TenderReportId = tenderReportFromDB.TenderReportId;
            _context.Entry(tenderReportFromDB).CurrentValues.SetValues(tenderReport);
            _context.Entry(tenderReportFromDB).Property(x => x.CreatedDate).IsModified = false;
            _context.Entry(tenderReportFromDB).Property(x => x.CreatedBy).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}

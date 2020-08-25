using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Data.Entities;

namespace TenderReport.Data.Repositories
{
    public class TenderTypeRepository : ITenderTypeRepository
    {
        private readonly TendersContext _context;

        public TenderTypeRepository(TendersContext context)
        {
            _context = context;
        }
        public async Task CreateTender(TenderType tender)
        {
            _context.TenderType.Add(tender);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTender(string tenderCode)
        {
            var tenderFromDB = await _context.TenderType.FirstOrDefaultAsync(c => c.Code.Equals(tenderCode));
            tenderFromDB.IsDeleted = true;
            _context.Entry(tenderFromDB).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<TenderType>> GetAllTenders()
        {
            return await _context.TenderType.Where(c=>c.IsDeleted!= true).ToListAsync();
        }

        public async Task<bool> TenderExists(string tenderCode)
        {
            return await _context.TenderType.AnyAsync(c => c.Code.Equals(tenderCode));
        }

        public async Task UpdateTender(string tenderCode, TenderType tender)
        {
            var tenderFromDB = await _context.TenderType.FirstOrDefaultAsync(c => c.Code.Equals(tenderCode));
            tender.Code = tenderFromDB.Code;
            _context.Entry(tenderFromDB).CurrentValues.SetValues(tender);
            _context.Entry(tenderFromDB).Property(x => x.CreatedDate).IsModified = false;
            _context.Entry(tenderFromDB).Property(x => x.CreatedBy).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}

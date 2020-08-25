using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Data.Entities;

namespace TenderReport.Data.Repositories
{
    public class ExpenditureTypeRepository : IExpenditureTypeRepository
    {
        private readonly TendersContext _context;

        public ExpenditureTypeRepository(TendersContext context)
        {
            _context = context;
        }
        public async Task CreateExpenditure(ExpenditureType Expenditure)
        {
            _context.ExpenditureType.Add(Expenditure);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpenditure(string ExpenditureCode)
        {
            var ExpenditureFromDB = await _context.ExpenditureType.FirstOrDefaultAsync(c => c.Code.Equals(ExpenditureCode));
            ExpenditureFromDB.IsDeleted = true;
            _context.Entry(ExpenditureFromDB).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExpenditureExists(string code)
        {
            return await _context.ExpenditureType.AnyAsync(c => c.Code.Equals(code));
        }

        public async Task<List<ExpenditureType>> GetAllExpenditures()
        {
            return await _context.ExpenditureType.Where(c => c.IsDeleted != true).ToListAsync();
        }

        public async Task UpdateExpenditure(string ExpenditureCode, ExpenditureType Expenditure)
        {
            var ExpenditureFromDB = await _context.ExpenditureType.FirstOrDefaultAsync(c => c.Code.Equals(ExpenditureCode));
            Expenditure.Code = ExpenditureFromDB.Code;
            _context.Entry(ExpenditureFromDB).CurrentValues.SetValues(Expenditure);
            _context.Entry(ExpenditureFromDB).Property(x => x.CreatedDate).IsModified = false;
            _context.Entry(ExpenditureFromDB).Property(x => x.CreatedBy).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}

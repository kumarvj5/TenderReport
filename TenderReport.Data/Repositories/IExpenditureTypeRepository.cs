using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Data.Entities;

namespace TenderReport.Data.Repositories
{
    public interface IExpenditureTypeRepository
    {
        Task CreateExpenditure(ExpenditureType Expenditure);
        Task DeleteExpenditure(string ExpenditureCode);
        Task<List<ExpenditureType>> GetAllExpenditures();
        Task UpdateExpenditure(string ExpenditureCode, ExpenditureType Expenditure);
    }
}

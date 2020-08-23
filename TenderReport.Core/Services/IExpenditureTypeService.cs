using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Core.Models;

namespace TenderReport.Core.Services
{
    public interface IExpenditureTypeService
    {
        Task<List<CodesViewDTO>> GetAllExpenditures();
        Task CreateExpenditure(CodesCreateDTO ExpendituresDTO);
        Task UpdateExpenditure(string ExpenditureCode, CodesCreateDTO ExpendituresDTO);
        Task DeleteExpenditure(string ExpenditureCode);
    }
}

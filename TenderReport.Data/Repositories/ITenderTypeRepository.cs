using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Data.Entities;

namespace TenderReport.Data.Repositories
{
    public interface ITenderTypeRepository
    {
        Task CreateTender(TenderType tender);
        Task DeleteTender(string tenderCode);
        Task<List<TenderType>> GetAllTenders();
        Task UpdateTender(string tenderCode, TenderType tender);
    }
}

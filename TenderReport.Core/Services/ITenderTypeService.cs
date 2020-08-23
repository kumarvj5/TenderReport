using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Core.Models;

namespace TenderReport.Core.Services
{
    public interface ITenderTypeService
    {
        Task<List<CodesViewDTO>> GetAllTenders();
        Task CreateTender(CodesCreateDTO tendersDTO);
        Task UpdateTender(string tenderCode, CodesCreateDTO tendersDTO);
        Task DeleteTender(string tenderCode);
    }
}

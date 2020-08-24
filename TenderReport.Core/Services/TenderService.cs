using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Core.Models;
using TenderReport.Data.Repositories;

namespace TenderReport.Core.Services
{
    public class TenderService : ITenderService
    {
        private readonly IMapper _mapper;
        private readonly ITenderRepository _repository;

        public TenderService(IMapper mapper, ITenderRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateTenderReport(ReportCreateDTO reportCreateDTO)
        {
            var entity = _mapper.Map<Data.Entities.TenderReport>(reportCreateDTO);
            entity.ParticularName = TenderHelperService.ToTitleCase(entity.ParticularName);
            await _repository.CreateTenderReport(entity);
        }

        public async Task DeleteTenderReport(Guid templateReportId)
        {
            await _repository.DeleteTenderReport(templateReportId);
        }

        public async Task<ReportView> GetAllTenderReports(string tenderType)
        {
            var reportView = new ReportView();
            var tender = await _repository.GetTende(tenderType);
            var tenderReportList = await _repository.GetAllTenderReports(tenderType);
            reportView.Reports = _mapper.Map<List<ReportViewDTO>>(tenderReportList);
            reportView.TenderAmount = tender[0].Amount;
            return reportView;
        }

        public async Task<OverallDTO> GetOverallTenderReports(string tenderType)
        {
            var overall = new OverallDTO();
            overall.Tender = _mapper.Map<List<CodesViewDTO>>(await _repository.GetTende(tenderType));
            var tenderList = await _repository.GetAllTenderReports(tenderType);
            var groupedList = tenderList.GroupBy(c => c.ExpenditureType).ToDictionary(c => c.Key, k => k.ToList());
            foreach (var item in groupedList)
            {
                overall.TenderSummary.Add(new Summary { ExpenditureType = item.Key, Amount = item.Value.Sum(c => c.Amount)});
            }
            overall.TenderAmount = overall.Tender.Sum(c => c.Amount);
            overall.TotalAmount = overall.TenderSummary.Sum(c => c.Amount);
            overall.TenderSummary.ForEach(c => c.Share =c.Amount / overall.TenderAmount);

            if (overall.TenderSummary.Sum(c=>c.Amount) > overall.Tender.Sum(c => c.Amount))
            {
                overall.Loss = overall.TenderSummary.Sum(c => c.Amount) - overall.Tender.Sum(c => c.Amount);
            }
            else
            {
                overall.Profit = overall.Tender.Sum(c => c.Amount) - overall.TenderSummary.Sum(c => c.Amount);
            }
            return overall;
        }

        public async Task<SplitReports> GetSplitTenderReports(string tenderType)
        {
            var splitReports = new SplitReports();
            var tender = await _repository.GetTende(tenderType);
            var tenderReportList = await _repository.GetAllTenderReports(tenderType);
            var groupedList = tenderReportList.GroupBy(c => c.ExpenditureType).ToDictionary(c=>c.Key, k=>k.ToList());

            splitReports.TenderAmount = tender[0].Amount;
            foreach (var group in groupedList)
            {
                splitReports.Reports.Add(new SplitReportsDTO { ExpenditureType = group.Key, Reports = _mapper.Map<List<ReportViewDTO>>(group.Value), Count= group.Value.Count(), Amount= group.Value.Sum(c=>c.Amount) });
            }
            return splitReports;
        }

        public async Task UpdateTenderReport(Guid templateReportId, ReportCreateDTO reportCreateDTO)
        {
            var entity = _mapper.Map<Data.Entities.TenderReport>(reportCreateDTO);
            entity.ParticularName = TenderHelperService.ToTitleCase(entity.ParticularName);
            await _repository.UpdateTenderReport(templateReportId,entity);
        }
    }
}

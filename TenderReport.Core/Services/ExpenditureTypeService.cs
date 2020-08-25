using AutoMapper;
using TenderReport.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Core.Models;
using TenderReport.Data.Entities;
using TenderReport.Data.Repositories;
using System.Text.RegularExpressions;

namespace TenderReport.Core.Services
{
    public class ExpenditureTypeService : IExpenditureTypeService
    {
        private readonly IExpenditureTypeRepository _repository;
        private readonly IMapper _mapper;

        public ExpenditureTypeService(IExpenditureTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateExpenditure(CodesCreateDTO ExpendituresDTO)
        {
            var entity = _mapper.Map<ExpenditureType>(ExpendituresDTO);
            Regex.Replace(entity.Code, @"\s+", "");
            entity.Code = TenderHelperService.ToTitleCase(entity.Code);
            entity.ShortName = TenderHelperService.ToTitleCase(entity.ShortName);
            await _repository.CreateExpenditure(entity);
        }

        public async Task DeleteExpenditure(string ExpenditureCode)
        {
            await _repository.DeleteExpenditure(ExpenditureCode);
        }

        public async Task<List<CodesViewDTO>> GetAllExpenditures()
        {
            var ExpendituresList = await _repository.GetAllExpenditures();
            return _mapper.Map<List<CodesViewDTO>>(ExpendituresList);
        }

        public async Task UpdateExpenditure(string ExpenditureCode, CodesCreateDTO ExpendituresDTO)
        {
            var entity = _mapper.Map<ExpenditureType>(ExpendituresDTO);
            entity.ShortName = TenderHelperService.ToTitleCase(entity.ShortName);
            await _repository.UpdateExpenditure(ExpenditureCode, entity);
        }
    }
}

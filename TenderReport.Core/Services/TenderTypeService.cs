using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenderReport.Core.Models;
using TenderReport.Data.Entities;
using TenderReport.Data.Repositories;

namespace TenderReport.Core.Services
{
    public class TenderTypeService : ITenderTypeService
    {
        private readonly ITenderTypeRepository _repository;
        private readonly IMapper _mapper;

        public TenderTypeService(ITenderTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateTender(CodesCreateDTO tendersDTO)
        {
            var entity = _mapper.Map<TenderType>(tendersDTO);
            entity.Code = TenderHelperService.ToTitleCase(entity.Code);
            entity.ShortName = TenderHelperService.ToTitleCase(entity.ShortName);
            await _repository.CreateTender(entity);
        }

        public async Task DeleteTender(string tenderCode)
        {
            await _repository.DeleteTender(tenderCode);
        }

        public async Task<List<CodesViewDTO>> GetAllTenders()
        {
            var tendersList = await _repository.GetAllTenders();
            return _mapper.Map<List<CodesViewDTO>>(tendersList);
        }

        public async Task UpdateTender(string tenderCode, CodesCreateDTO tendersDTO)
        {
            var entity = _mapper.Map<TenderType>(tendersDTO);
            entity.ShortName = TenderHelperService.ToTitleCase(entity.ShortName);
            await _repository.UpdateTender(tenderCode, entity);
        }
    }
}

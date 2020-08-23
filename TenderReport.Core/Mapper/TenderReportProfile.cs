using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TenderReport.Core.Models;
using TenderReport.Data.Entities;

namespace TenderReport.Core.Mapper
{
    public class TenderReportProfile: Profile
    {
        public TenderReportProfile()
        {
            CreateMap<TenderType, CodesViewDTO>().ForMember(c => c.Description, opt => opt.MapFrom(o => o.ShortName))
                .ForMember(c => c.Amount, opt => opt.MapFrom(o =>o.Amount.ToString()))
                .ForMember(c => c.CreatedDate, opt => opt.MapFrom(o => o.CreatedDate.ToString("dd MMM yyyy")));
            CreateMap<ExpenditureType, CodesViewDTO>().ForMember(c => c.Description, opt => opt.MapFrom(o => o.ShortName))
                .ForMember(c => c.CreatedDate, opt => opt.MapFrom(o => o.CreatedDate.ToString("dd MMM yyyy")));

            CreateMap<CodesCreateDTO, TenderType>().ForMember(c => c.ShortName, opt => opt.MapFrom(o => o.Description))
            .ForMember(c => c.Amount, opt => opt.MapFrom(o => Convert.ToDecimal(o.Amount)));
            CreateMap<CodesCreateDTO, ExpenditureType>().ForMember(c => c.ShortName, opt => opt.MapFrom(o => o.Description));

            CreateMap<ReportCreateDTO, Data.Entities.TenderReport>().ForMember(c => c.ParticularName, opt => opt.MapFrom(o => o.ItemName))
                .ForMember(c => c.Amount, opt => opt.MapFrom(o => Convert.ToDecimal(o.Amount))); ;
            CreateMap<Data.Entities.TenderReport, ReportViewDTO>().ForMember(c => c.ItemName, opt => opt.MapFrom(o => o.ParticularName))
                .ForMember(c => c.Amount, opt => opt.MapFrom(o => o.Amount.ToString()))
                .ForMember(c => c.CreatedDate, opt => opt.MapFrom(o => o.CreatedDate.ToString("dd MMM yyyy")));
        }
    }
}

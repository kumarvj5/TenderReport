using System;
using System.Collections.Generic;
using System.Text;

namespace TenderReport.Core.Models
{
    public class OverallDTO
    {
        public OverallDTO()
        {
            Tender = new List<CodesViewDTO>();
            TenderSummary = new List<Summary>();
        }
        public List<CodesViewDTO> Tender { get; set; }
        public List<Summary> TenderSummary { get; set; }
        public decimal? Profit { get; set; }
        public decimal? Loss { get; set; }
        public decimal TenderAmount { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class Summary 
    {
        public string ExpenditureType { get; set; }
        public decimal Amount { get; set; }
        public decimal Share { get; set; }
    }
}

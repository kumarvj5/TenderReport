using System;
using System.Collections.Generic;
using System.Text;

namespace TenderReport.Core.Models
{
    public class SplitReports
    {
        public SplitReports()
        {
            Reports = new List<SplitReportsDTO>();
        }
        public decimal TenderAmount { get; set; }
        public List<SplitReportsDTO> Reports { get; set; }
    }
    public class SplitReportsDTO
    {
        public SplitReportsDTO()
        {
            Reports = new List<ReportViewDTO>();
        }
        public string ExpenditureType { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        public List<ReportViewDTO> Reports { get; set; }
    }
}

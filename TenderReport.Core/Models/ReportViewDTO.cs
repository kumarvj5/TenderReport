using System;
using System.Collections.Generic;
using System.Text;

namespace TenderReport.Core.Models
{
    public class ReportView
    {
        public ReportView()
        {
            Reports = new List<ReportViewDTO>();
        }
        public decimal TenderAmount { get; set; }
        public List<ReportViewDTO> Reports { get; set; }
    }
    public class ReportViewDTO
    {
        public Guid TenderReportId { get; set; }
        public string ItemName { get; set; }
        public string ExpenditureType { get; set; }
        public string TenderType { get; set; }
        public decimal Amount { get; set; }
        public string CreatedDate { get; set; }
    }
}

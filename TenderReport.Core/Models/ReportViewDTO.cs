using System;
using System.Collections.Generic;
using System.Text;

namespace TenderReport.Core.Models
{
    public class ReportViewDTO
    {
        public Guid TenderReportId { get; set; }
        public string ItemName { get; set; }
        public string ExpenditureType { get; set; }
        public string TenderType { get; set; }
        public decimal Amount { get; set; }
        public string CreatedDate { get; set; }
        public decimal TenderAmount { get; set; }
    }
}

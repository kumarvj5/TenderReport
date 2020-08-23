using System;
using System.Collections.Generic;
using System.Text;

namespace TenderReport.Core.Models
{
    public class ReportCreateDTO
    {
        public string ItemName { get; set; }
        public string ExpenditureType { get; set; }
        public string TenderType { get; set; }
        public string Amount { get; set; }
    }
}

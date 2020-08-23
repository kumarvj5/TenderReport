using System;
using System.Collections.Generic;
using System.Text;

namespace TenderReport.Core.Models
{
    public class CodesViewDTO
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public decimal Amount { get; set; }
    }
}

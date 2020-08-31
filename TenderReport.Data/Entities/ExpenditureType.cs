using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenderReport.Data.Entities
{
    public partial class ExpenditureType
    {
        [Key]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string ShortName { get; set; }
        public short? SortOrder { get; set; }
        [Required]
        [StringLength(20)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(20)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

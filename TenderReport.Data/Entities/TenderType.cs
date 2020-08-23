using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenderReport.Data.Entities
{
    public partial class TenderType
    {
        public TenderType()
        {
            TenderReport = new HashSet<TenderReport>();
        }

        [Key]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string ShortName { get; set; }
        public short? SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [StringLength(20)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(20)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [InverseProperty("TendertypeNavigation")]
        public virtual ICollection<TenderReport> TenderReport { get; set; }
    }
}

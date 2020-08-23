using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenderReport.Data.Entities
{
    public partial class TenderReport
    {
        [Key]
        [Column("TenderReportID")]
        public Guid TenderReportId { get; set; }
        [Required]
        [StringLength(100)]
        public string ParticularName { get; set; }
        [Required]
        [StringLength(50)]
        public string ExpenditureType { get; set; }
        [Required]
        [StringLength(50)]
        public string Tendertype { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(20)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        [StringLength(20)]
        public string ModifiedBy { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(ExpenditureType))]
        [InverseProperty("TenderReport")]
        public virtual ExpenditureType ExpenditureTypeNavigation { get; set; }
        [ForeignKey(nameof(Tendertype))]
        [InverseProperty(nameof(TenderType.TenderReport))]
        public virtual TenderType TendertypeNavigation { get; set; }
    }
}

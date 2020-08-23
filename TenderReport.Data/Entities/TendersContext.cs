using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TenderReport.Data.Entities
{
    public partial class TendersContext : DbContext
    {
        public TendersContext()
        {
        }

        public TendersContext(DbContextOptions<TendersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExpenditureType> ExpenditureType { get; set; }
        public virtual DbSet<TenderReport> TenderReport { get; set; }
        public virtual DbSet<TenderType> TenderType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenditureType>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_CODE.ExpenditureType");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('Vijay')");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TenderReport>(entity =>
            {
                entity.Property(e => e.TenderReportId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('Vijay')");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpenditureType).IsUnicode(false);

                entity.Property(e => e.Tendertype).IsUnicode(false);

                entity.HasOne(d => d.ExpenditureTypeNavigation)
                    .WithMany(p => p.TenderReport)
                    .HasForeignKey(d => d.ExpenditureType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TenderReport_ExpenditureType");

                entity.HasOne(d => d.TendertypeNavigation)
                    .WithMany(p => p.TenderReport)
                    .HasForeignKey(d => d.Tendertype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TenderReport_TenderType");
            });

            modelBuilder.Entity<TenderType>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_CODE.TenderType");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("('Vijay')");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

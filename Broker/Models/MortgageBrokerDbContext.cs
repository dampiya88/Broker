using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Broker.Models
{
    public partial class MortgageBrokerDbContext : DbContext
    {
        public MortgageBrokerDbContext()
        {
        }

        public MortgageBrokerDbContext(DbContextOptions<MortgageBrokerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Associate> Associates { get; set; }
        public virtual DbSet<AssociateCommission> AssociateCommissions { get; set; }
        public virtual DbSet<CommissionSplit> CommissionSplits { get; set; }
        public virtual DbSet<CommissionsPaid> CommissionsPaids { get; set; }
        public virtual DbSet<CommissionsPaidProduct> CommissionsPaidProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=desktop-khq3vne\\sqlexpress; Initial Catalog=MortgageBrokerDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Associate>(entity =>
            {
                entity.Property(e => e.AssociateId).HasColumnName("AssociateID");

                entity.Property(e => e.AssociateFirstName).HasMaxLength(50);

                entity.Property(e => e.AssociateLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.DateOfPayment).HasColumnType("date");

                entity.Property(e => e.SplitId).HasColumnName("SplitID");
            });

            modelBuilder.Entity<AssociateCommission>(entity =>
            {
                entity.Property(e => e.AssociateCommissionId).HasColumnName("AssociateCommissionID");

                entity.Property(e => e.AssociateCommission1).HasColumnName("AssociateCommission");

                entity.Property(e => e.AssociateId).HasColumnName("AssociateID");

                entity.Property(e => e.CommissionSplitId).HasColumnName("CommissionSplitID");

                entity.Property(e => e.CreatedBy).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.LastUpdateDate).HasColumnType("date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Associate)
                    .WithMany(p => p.AssociateCommissions)
                    .HasForeignKey(d => d.AssociateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssociateCommissions_Associates");
            });

            modelBuilder.Entity<CommissionSplit>(entity =>
            {
                entity.Property(e => e.CommissionSplitId).HasColumnName("CommissionSplitID");
            });

            modelBuilder.Entity<CommissionsPaid>(entity =>
            {
                entity.ToTable("CommissionsPaid");

                entity.Property(e => e.CommissionsPaidId)
                    .ValueGeneratedNever()
                    .HasColumnName("CommissionsPaidID");

                entity.Property(e => e.CommissionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DatePaid).HasColumnType("date");

                entity.Property(e => e.LastUpdateDate).HasColumnType("date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CommissionsPaidProduct>(entity =>
            {
                entity.Property(e => e.CommissionsPaidProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("CommissionsPaidProductID");

                entity.Property(e => e.Commission).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CommissionsPaidId).HasColumnName("CommissionsPaidID");

                entity.Property(e => e.CreatedBy).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.LastUpdateDate).HasColumnType("date");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.CommissionsPaid)
                    .WithMany(p => p.CommissionsPaidProducts)
                    .HasForeignKey(d => d.CommissionsPaidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommissionsPaidProducts_CommissionsPaid");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ApplicationNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AssociateId).HasColumnName("AssociateID");

                entity.Property(e => e.BorrowerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DateFunded).HasColumnType("date");

                entity.Property(e => e.LastUpdateDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MortgageAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductDescription).HasMaxLength(50);

                entity.Property(e => e.TotalFileCommissions).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Associate)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AssociateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Associates");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

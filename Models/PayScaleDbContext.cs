using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace D49E01.Models
{
    public partial class PayScaleDbContext : DbContext
    {
        public PayScaleDbContext()
        {
        }

        public PayScaleDbContext(DbContextOptions<PayScaleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-1U8CLEA;database=PayScaleDb;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PayBand)
                    .HasName("PK__payment__66B0F53F1F494EC6");

                entity.ToTable("payment");

                entity.HasIndex(e => e.BasicSalary, "UQ__payment__B589ED30F36E1802")
                    .IsUnique();

                entity.Property(e => e.PayBand).HasMaxLength(1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QR2.Models;

namespace QR2.DAL;

public partial class QrContext : DbContext
{
    public QrContext()
    {
    }

    public QrContext(DbContextOptions<QrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarbonFootprint> CarbonFootprints { get; set; }

    public virtual DbSet<CarbonFootprintAudit> CarbonFootprintAudits { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Qrcode> Qrcodes { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ABQM63U\\SQLEXPRESS;Database=QR;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarbonFootprint>(entity =>
        {
            entity.HasKey(e => e.CarbonFootprintId).HasName("PK__CarbonFo__5847DECE6792EF69");

            entity.ToTable("CarbonFootprint", tb => tb.HasTrigger("trg_UpdateCarbonFootprint"));

            entity.Property(e => e.CarbonFootprintId).HasColumnName("CarbonFootprintID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.CarbonFootprints)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_CarbonFootprint_Product");
        });

        modelBuilder.Entity<CarbonFootprintAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__CarbonFo__A17F23B8B08F74BB");

            entity.ToTable("CarbonFootprintAudit");

            entity.Property(e => e.AuditId).HasColumnName("AuditID");
            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.AuditDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.CarbonFootprintAudits)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_CarbonFootprintAudit_Product");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971C4C6BAE0A20");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDED6275D3");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Company).WithMany(p => p.Products)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Product_Company");
        });

        modelBuilder.Entity<Qrcode>(entity =>
        {
            entity.HasKey(e => e.QrcodeId).HasName("PK__QRCode__62FECDF2B39E9D3C");

            entity.ToTable("QRCode");

            entity.Property(e => e.QrcodeId).HasColumnName("QRCodeID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.Qrcodes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_QRCode_Product");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserAcco__1788CCACBC73C2F8");

            entity.ToTable("UserAccount");

            entity.HasIndex(e => e.Email, "UQ__UserAcco__A9D10534C70216A0").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

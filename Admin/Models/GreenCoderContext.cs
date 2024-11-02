using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Admin.Models;

public partial class GreenCoderContext : DbContext
{
    public GreenCoderContext()
    {
    }

    public GreenCoderContext(DbContextOptions<GreenCoderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=Green_Coder;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DonHang__3214EC27EBE66CCA");

            entity.ToTable("DonHang");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasColumnType("ntext");
            entity.Property(e => e.NgayBan).HasColumnType("datetime");
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.SoHieuNguoiBan).HasMaxLength(50);
            entity.Property(e => e.TenKhachHang).HasMaxLength(50);
            entity.Property(e => e.TenNguoiBan).HasMaxLength(50);
            entity.Property(e => e.TenSanPham).HasMaxLength(50);
            entity.Property(e => e.TinhTrang).HasMaxLength(50);

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaSanPham)
                .HasConstraintName("FK__DonHang__MaSanPh__4BAC3F29");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SanPham__3214EC2765C96401");

            entity.ToTable("SanPham");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AnhSanPham).HasColumnType("image");
            entity.Property(e => e.DanhMuc).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasColumnType("ntext");
            entity.Property(e => e.NhaCungCap).HasMaxLength(50);
            entity.Property(e => e.TenSanPham).HasMaxLength(50);
            entity.Property(e => e.TinhTrang).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

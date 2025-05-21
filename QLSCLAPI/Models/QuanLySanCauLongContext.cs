using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLSCLAPI.Models;

public partial class QuanLySanCauLongContext : DbContext
{
    public QuanLySanCauLongContext()
    {
    }

    public QuanLySanCauLongContext(DbContextOptions<QuanLySanCauLongContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatSan> DatSans { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HuyDatSan> HuyDatSans { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NhatKyHoatDong> NhatKyHoatDongs { get; set; }

    public virtual DbSet<PhanHoi> PhanHois { get; set; }

    public virtual DbSet<PhienDangNhap> PhienDangNhaps { get; set; }

    public virtual DbSet<San> Sans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=172.20.10.10;Database=QuanLySanCauLong;User Id=sa;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatSan>(entity =>
        {
            entity.HasKey(e => e.MaDatSan).HasName("PK__DatSan__747DC2D345CF3B49");

            entity.ToTable("DatSan");

            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("đã đặt");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DatSans)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DatSan__MaKhachH__4E88ABD4");

            entity.HasOne(d => d.MaSanNavigation).WithMany(p => p.DatSans)
                .HasForeignKey(d => d.MaSan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DatSan__MaSan__4F7CD00D");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13BC0D24DD6");

            entity.ToTable("HoaDon");

            entity.HasIndex(e => e.MaDatSan, "UQ__HoaDon__747DC2D258930A75").IsUnique();

            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.SoTien).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ThoiGianThanhToan).HasColumnType("datetime");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("chưa thanh toán");

            entity.HasOne(d => d.MaDatSanNavigation).WithOne(p => p.HoaDon)
                .HasForeignKey<HoaDon>(d => d.MaDatSan)
                .HasConstraintName("FK__HoaDon__MaDatSan__5441852A");
        });

        modelBuilder.Entity<HuyDatSan>(entity =>
        {
            entity.HasKey(e => e.MaHuy).HasName("PK__HuyDatSa__3C8A1634409AECE7");

            entity.ToTable("HuyDatSan");

            entity.Property(e => e.LyDo).HasMaxLength(255);
            entity.Property(e => e.ThoiGianHuy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaDatSanNavigation).WithMany(p => p.HuyDatSans)
                .HasForeignKey(d => d.MaDatSan)
                .HasConstraintName("FK__HuyDatSan__MaDat__5812160E");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5F56A61B1");

            entity.ToTable("KhachHang");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_KhachHang_NguoiDung");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D76247A6D481");

            entity.ToTable("NguoiDung");

            entity.HasIndex(e => e.TenDangNhap, "UQ__NguoiDun__55F68FC0DACCC287").IsUnique();

            entity.Property(e => e.MatKhauHash).HasMaxLength(255);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
            entity.Property(e => e.VaiTro)
                .HasMaxLength(20)
                .HasDefaultValue("nhân viên");
        });

        modelBuilder.Entity<NhatKyHoatDong>(entity =>
        {
            entity.HasKey(e => e.MaNhatKy).HasName("PK__NhatKyHo__E42EF42E28D7AFAF");

            entity.ToTable("NhatKyHoatDong");

            entity.Property(e => e.BangTacDong).HasMaxLength(50);
            entity.Property(e => e.HanhDong).HasMaxLength(100);
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.ThoiGian)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.NhatKyHoatDongs)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK__NhatKyHoa__MaNgu__656C112C");
        });

        modelBuilder.Entity<PhanHoi>(entity =>
        {
            entity.HasKey(e => e.MaPhanHoi).HasName("PK__PhanHoi__3458D20F1A28E98E");

            entity.ToTable("PhanHoi");

            entity.Property(e => e.NoiDung).HasMaxLength(500);
            entity.Property(e => e.ThoiGianGopY)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__PhanHoi__MaKhach__5BE2A6F2");

            entity.HasOne(d => d.MaSanNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaSan)
                .HasConstraintName("FK__PhanHoi__MaSan__5CD6CB2B");
        });

        modelBuilder.Entity<PhienDangNhap>(entity =>
        {
            entity.HasKey(e => e.MaPhien).HasName("PK__PhienDan__2660BFEFC8C8211A");

            entity.ToTable("PhienDangNhap");

            entity.Property(e => e.DiaChiIp)
                .HasMaxLength(50)
                .HasColumnName("DiaChiIP");
            entity.Property(e => e.HetHan).HasColumnType("datetime");
            entity.Property(e => e.ThietBi).HasMaxLength(255);
            entity.Property(e => e.ThoiGianTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Token).HasMaxLength(255);

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.PhienDangNhaps)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhienDang__MaNgu__693CA210");
        });

        modelBuilder.Entity<San>(entity =>
        {
            entity.HasKey(e => e.MaSan).HasName("PK__San__3188C826C2C4FD8E");

            entity.ToTable("San");

            entity.Property(e => e.TenSan).HasMaxLength(50);
            entity.Property(e => e.TinhTrang)
                .HasMaxLength(20)
                .HasDefaultValue("đang hoạt động");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BaiTapLon.DataModels
{
    public partial class QLKhachSanContext : DbContext
    {
        public QLKhachSanContext()
        {
        }

        public QLKhachSanContext(DbContextOptions<QLKhachSanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
        public virtual DbSet<ChiTietThuePhong> ChiTietThuePhongs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuDatPhong> PhieuDatPhongs { get; set; }
        public virtual DbSet<PhieuDichVu> PhieuDichVus { get; set; }
        public virtual DbSet<PhieuThuePhong> PhieuThuePhongs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-T6EQDLO;Initial Catalog=QLKhachSan;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietDatPhong>(entity =>
            {
                entity.HasKey(e => new { e.MaPhieuDatPhong, e.MaPhong })
                    .HasName("PK__ChiTietD__6B1D74620519DC0A");

                entity.ToTable("ChiTietDatPhong");

                entity.Property(e => e.MaPhieuDatPhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaPhieuDatPhongNavigation)
                    .WithMany(p => p.ChiTietDatPhongs)
                    .HasForeignKey(d => d.MaPhieuDatPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ma_pdat_phong");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.ChiTietDatPhongs)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ma_phong");
            });

            modelBuilder.Entity<ChiTietThuePhong>(entity =>
            {
                entity.HasKey(e => new { e.MaPhong, e.MaPhieuThuePhong })
                    .HasName("PK__ChiTietT__0B8A21E6BCF0C400");

                entity.ToTable("ChiTietThuePhong");

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaPhieuThuePhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaPhieuThuePhongNavigation)
                    .WithMany(p => p.ChiTietThuePhongs)
                    .HasForeignKey(d => d.MaPhieuThuePhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCTThuePhong_maPhieuThue");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.ChiTietThuePhongs)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCTThuePhong_maP");
            });

            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.MaDv)
                    .HasName("PK__DichVu__272586572F06857E");

                entity.ToTable("DichVu");

                entity.Property(e => e.MaDv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaDV")
                    .HasDefaultValueSql("([dbo].[AUTO_IDDichVu]())")
                    .IsFixedLength(true);

                entity.Property(e => e.DonGiaDv).HasColumnName("DonGiaDV");

                entity.Property(e => e.MaLoaiDv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaLoaiDV")
                    .IsFixedLength(true);

                entity.Property(e => e.TenDv)
                    .HasMaxLength(100)
                    .HasColumnName("TenDV");

                entity.HasOne(d => d.MaLoaiDvNavigation)
                    .WithMany(p => p.DichVus)
                    .HasForeignKey(d => d.MaLoaiDv)
                    .HasConstraintName("fkDV_maLoaiDV");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__HoaDon__835ED13BDC0C01F7");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[AUTO_IDHoaDon]())")
                    .IsFixedLength(true);

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MaPhieuThuePhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("fkHD_maNhanVien");

                entity.HasOne(d => d.MaPhieuThuePhongNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaPhieuThuePhong)
                    .HasConstraintName("fkHD_maPhieuThue");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KhachHan__2725CF1E11DC336B");

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaKH")
                    .HasDefaultValueSql("([dbo].[AUTO_IDKH]())")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.SoCmnd)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SoCMND")
                    .IsFixedLength(true);

                entity.Property(e => e.TenKhach).HasMaxLength(500);
            });

            modelBuilder.Entity<LoaiDichVu>(entity =>
            {
                entity.HasKey(e => e.MaLoaiDv)
                    .HasName("PK__LoaiDich__1227486581B351AF");

                entity.ToTable("LoaiDichVu");

                entity.Property(e => e.MaLoaiDv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaLoaiDV")
                    .HasDefaultValueSql("([dbo].[AUTO_IDLoaiDichVu]())")
                    .IsFixedLength(true);

                entity.Property(e => e.TenLoaiDv)
                    .HasMaxLength(100)
                    .HasColumnName("TenLoaiDV");
            });

            modelBuilder.Entity<LoaiPhong>(entity =>
            {
                entity.HasKey(e => e.MaLoaiPhong)
                    .HasName("PK__LoaiPhon__23021217B6A3C879");

                entity.ToTable("LoaiPhong");

                entity.Property(e => e.MaLoaiPhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[AUTO_IDLoaiPhong]())")
                    .IsFixedLength(true);

                entity.Property(e => e.TenLoai).HasMaxLength(100);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NhanVien__77B2CA47372E33D6");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[AUTO_IDNhanVien]())")
                    .IsFixedLength(true);

                entity.Property(e => e.ChucVu).HasMaxLength(100);

                entity.Property(e => e.DiaChi).HasMaxLength(500);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaiKhoan)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhanVien).HasMaxLength(100);
            });

            modelBuilder.Entity<PhieuDatPhong>(entity =>
            {
                entity.HasKey(e => e.MaPhieuDatPhong)
                    .HasName("PK__PhieuDat__C916A1873E7F687C");

                entity.ToTable("PhieuDatPhong");

                entity.Property(e => e.MaPhieuDatPhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[AUTO_IDPhieuDatPhong]())")
                    .IsFixedLength(true);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaKH")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayNhan).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.PhieuDatPhongs)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("fk_ma_kh");
            });

            modelBuilder.Entity<PhieuDichVu>(entity =>
            {
                entity.HasKey(e => e.MaPhieuDichVu)
                    .HasName("PK__PhieuDic__391A60BCDBFAEC55");

                entity.ToTable("PhieuDichVu");

                entity.Property(e => e.MaPhieuDichVu)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[AUTO_IDPhieuDichVu]())")
                    .IsFixedLength(true);

                entity.Property(e => e.MaDv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaDV")
                    .IsFixedLength(true);

                entity.Property(e => e.MaPhieuThuePhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaDvNavigation)
                    .WithMany(p => p.PhieuDichVus)
                    .HasForeignKey(d => d.MaDv)
                    .HasConstraintName("fkPhieuDV_maDV");

                entity.HasOne(d => d.MaPhieuThuePhongNavigation)
                    .WithMany(p => p.PhieuDichVus)
                    .HasForeignKey(d => d.MaPhieuThuePhong)
                    .HasConstraintName("fkPhieuDV_mPhieuThueP");
            });

            modelBuilder.Entity<PhieuThuePhong>(entity =>
            {
                entity.HasKey(e => e.MaPhieuThuePhong)
                    .HasName("PK__PhieuThu__B377FBD385E7FD24");

                entity.ToTable("PhieuThuePhong");

                entity.Property(e => e.MaPhieuThuePhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[AUTO_IDPhieuThuePhong]())")
                    .IsFixedLength(true);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaKH")
                    .IsFixedLength(true);

                entity.Property(e => e.NgayDen).HasColumnType("datetime");

                entity.Property(e => e.NgayDi).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.PhieuThuePhongs)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("fkThuePhong_maKH");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PK__Phong__20BD5E5BDADC661F");

                entity.ToTable("Phong");

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("([dbo].[AUTO_IDPhong]())")
                    .IsFixedLength(true);

                entity.Property(e => e.MaLoaiPhong)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaLoaiPhongNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.MaLoaiPhong)
                    .HasConstraintName("fk_loai_phong");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

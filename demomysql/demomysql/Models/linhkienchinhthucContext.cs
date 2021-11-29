using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace demomysql.Models
{
    public partial class linhkienchinhthucContext : DbContext
    {
        public linhkienchinhthucContext()
        {
        }

        public linhkienchinhthucContext(DbContextOptions<linhkienchinhthucContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anhthem> Anhthems { get; set; }
        public virtual DbSet<Binhluan> Binhluans { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Ctdh> Ctdhs { get; set; }
        public virtual DbSet<Danhgium> Danhgia { get; set; }
        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Donhang> Donhangs { get; set; }
        public virtual DbSet<Giaohang> Giaohangs { get; set; }
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Thuonghieu> Thuonghieus { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Vaitronguoidung> Vaitronguoidungs { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=Benten2001;database=linhkienchinhthuc");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anhthem>(entity =>
            {
                entity.HasKey(e => e.Maanh)
                    .HasName("PRIMARY");

                entity.ToTable("anhthem");

                entity.HasIndex(e => e.Masp, "FK_GOM");

                entity.Property(e => e.Maanh).HasColumnName("MAANH");

                entity.Property(e => e.Linkanh)
                    .HasMaxLength(1000)
                    .HasColumnName("LINKANH");

                entity.Property(e => e.Masp).HasColumnName("MASP");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("date")
                    .HasColumnName("NGAYTAO");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Anhthems)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GOM");
            });

            modelBuilder.Entity<Binhluan>(entity =>
            {
                entity.HasKey(e => e.Mabinhluan)
                    .HasName("PRIMARY");

                entity.ToTable("binhluan");

                entity.HasIndex(e => e.Manguoidung, "FK_VIET");

                entity.Property(e => e.Mabinhluan).HasColumnName("MABINHLUAN");

                entity.Property(e => e.Manguoidung).HasColumnName("MANGUOIDUNG");

                entity.Property(e => e.Ngaytao).HasColumnName("NGAYTAO");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(250)
                    .HasColumnName("NOIDUNG");

                entity.HasOne(d => d.ManguoidungNavigation)
                    .WithMany(p => p.Binhluans)
                    .HasForeignKey(d => d.Manguoidung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VIET");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Malh)
                    .HasName("PRIMARY");

                entity.ToTable("contact");

                entity.Property(e => e.Malh).HasColumnName("MALH");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(250)
                    .HasColumnName("HOTEN");

                entity.Property(e => e.Ngaygui).HasColumnName("NGAYGUI");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(250)
                    .HasColumnName("NOIDUNG");

                entity.Property(e => e.Tinhtrangdon)
                    .HasMaxLength(250)
                    .HasColumnName("TINHTRANGDON");
            });

            modelBuilder.Entity<Ctdh>(entity =>
            {
                entity.HasKey(e => new { e.Masp, e.Madonhang })
                    .HasName("PRIMARY");

                entity.ToTable("ctdh");

                entity.HasIndex(e => e.Madonhang, "FK_CTDH2");

                entity.Property(e => e.Masp)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MASP");

                entity.Property(e => e.Madonhang).HasColumnName("MADONHANG");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.MadonhangNavigation)
                    .WithMany(p => p.Ctdhs)
                    .HasForeignKey(d => d.Madonhang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTDH2");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Ctdhs)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTDH");
            });

            modelBuilder.Entity<Danhgium>(entity =>
            {
                entity.HasKey(e => e.Madanhgia)
                    .HasName("PRIMARY");

                entity.ToTable("danhgia");

                entity.HasIndex(e => e.Manguoidung, "FK_DANG");

                entity.Property(e => e.Madanhgia).HasColumnName("MADANHGIA");

                entity.Property(e => e.Manguoidung).HasColumnName("MANGUOIDUNG");

                entity.Property(e => e.Ngaydanhgia)
                    .HasColumnType("date")
                    .HasColumnName("NGAYDANHGIA");

                entity.Property(e => e.Sosao).HasColumnName("SOSAO");

                entity.HasOne(d => d.ManguoidungNavigation)
                    .WithMany(p => p.Danhgia)
                    .HasForeignKey(d => d.Manguoidung)
                    .HasConstraintName("FK_DANG");
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.Madm)
                    .HasName("PRIMARY");

                entity.ToTable("danhmuc");

                entity.Property(e => e.Madm).HasColumnName("MADM");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(150)
                    .HasColumnName("HINHANH");

                entity.Property(e => e.Mota)
                    .HasMaxLength(250)
                    .HasColumnName("_MOTA");

                entity.Property(e => e.Tendm)
                    .HasMaxLength(250)
                    .HasColumnName("TENDM");
            });

            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.HasKey(e => e.Madonhang)
                    .HasName("PRIMARY");

                entity.ToTable("donhang");

                entity.HasIndex(e => e.Mavoucher, "FK_APDUNG");

                entity.HasIndex(e => e.Manguoidung, "FK_CO");

                entity.HasIndex(e => e.Magiaohang, "FK_GIAO");

                entity.HasIndex(e => e.Idtransaction, "FK_TRANSACTION_idx");

                entity.Property(e => e.Madonhang).HasColumnName("MADONHANG");

                entity.Property(e => e.Bestseller)
                    .HasColumnType("bit(1)")
                    .HasColumnName("BESTSELLER");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(250)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(300)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(250)
                    .HasColumnName("GIOITINH");

                entity.Property(e => e.Homeflag)
                    .HasColumnType("bit(1)")
                    .HasColumnName("HOMEFLAG");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(250)
                    .HasColumnName("HOTEN");

                entity.Property(e => e.Idtransaction).HasColumnName("IDTRANSACTION");

                entity.Property(e => e.Magiaohang).HasColumnName("MAGIAOHANG");

                entity.Property(e => e.Manguoidung).HasColumnName("MANGUOIDUNG");

                entity.Property(e => e.Mavoucher).HasColumnName("MAVOUCHER");

                entity.Property(e => e.Ngaydat).HasColumnName("NGAYDAT");

                entity.Property(e => e.Ngayhethan).HasColumnName("NGAYHETHAN");

                entity.Property(e => e.Ngayship).HasColumnName("NGAYSHIP");

                entity.Property(e => e.Ngaythanhtoan).HasColumnName("NGAYTHANHTOAN");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.Property(e => e.Sotheodoi)
                    .HasMaxLength(50)
                    .HasColumnName("SOTHEODOI");

                entity.Property(e => e.Tinhtrangthanhtoan)
                    .HasMaxLength(100)
                    .HasColumnName("TINHTRANGTHANHTOAN");

                entity.Property(e => e.Tongdon).HasColumnName("TONGDON");

                entity.Property(e => e.Vanchuyen)
                    .HasMaxLength(50)
                    .HasColumnName("VANCHUYEN");

                entity.HasOne(d => d.IdtransactionNavigation)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.Idtransaction)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TRANSACTION");

                entity.HasOne(d => d.MagiaohangNavigation)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.Magiaohang)
                    .HasConstraintName("FK_GIAO");

                entity.HasOne(d => d.ManguoidungNavigation)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.Manguoidung)
                    .HasConstraintName("FK_CO");

                entity.HasOne(d => d.MavoucherNavigation)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.Mavoucher)
                    .HasConstraintName("FK_APDUNG");
            });

            modelBuilder.Entity<Giaohang>(entity =>
            {
                entity.HasKey(e => e.Magiaohang)
                    .HasName("PRIMARY");

                entity.ToTable("giaohang");

                entity.Property(e => e.Magiaohang).HasColumnName("MAGIAOHANG");

                entity.Property(e => e.Ngaygiao).HasColumnName("NGAYGIAO");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tennguoigiao)
                    .HasMaxLength(250)
                    .HasColumnName("TENNGUOIGIAO");

                entity.Property(e => e.Xacnhan)
                    .HasMaxLength(100)
                    .HasColumnName("XACNHAN");
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.Manguoidung)
                    .HasName("PRIMARY");

                entity.ToTable("nguoidung");

                entity.HasIndex(e => e.Madanhgia, "FK_DANG2");

                entity.HasIndex(e => e.Maquyen, "FK_PHANQUYEN");

                entity.Property(e => e.Manguoidung).HasColumnName("MANGUOIDUNG");

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(100)
                    .HasColumnName("DIENTHOAI");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(250)
                    .HasColumnName("HOTEN");

                entity.Property(e => e.Madanhgia).HasColumnName("MADANHGIA");

                entity.Property(e => e.Maquyen).HasColumnName("MAQUYEN");

                entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");

                entity.Property(e => e.Ngaysua).HasColumnName("NGAYSUA");

                entity.Property(e => e.Ngaytao).HasColumnName("NGAYTAO");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PasswordReset)
                    .HasMaxLength(250)
                    .HasColumnName("PASSWORD_RESET");

                entity.Property(e => e.Trangthai).HasColumnName("TRANGTHAI");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Vaitro)
                    .HasMaxLength(50)
                    .HasColumnName("VAITRO");

                entity.HasOne(d => d.MadanhgiaNavigation)
                    .WithMany(p => p.Nguoidungs)
                    .HasForeignKey(d => d.Madanhgia)
                    .HasConstraintName("FK_DANG2");

                entity.HasOne(d => d.MaquyenNavigation)
                    .WithMany(p => p.Nguoidungs)
                    .HasForeignKey(d => d.Maquyen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHANQUYEN");
            });

            modelBuilder.Entity<Nhacungcap>(entity =>
            {
                entity.HasKey(e => e.Mancc)
                    .HasName("PRIMARY");

                entity.ToTable("nhacungcap");

                entity.Property(e => e.Mancc).HasColumnName("MANCC");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(500)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("SDT");

                entity.Property(e => e.Tenncc)
                    .HasMaxLength(500)
                    .HasColumnName("TENNCC");

                entity.Property(e => e.Thanhpho)
                    .HasMaxLength(450)
                    .HasColumnName("THANHPHO");

                entity.Property(e => e.Tinhtrangxacnhan)
                    .HasColumnType("tinyint")
                    .HasColumnName("TINHTRANGXACNHAN");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PRIMARY");

                entity.ToTable("sanpham");

                entity.HasIndex(e => e.Madm, "FK_PHANLOAIDANHMUC");

                entity.HasIndex(e => e.Mathuonghieu, "FK_TRONG");

                entity.Property(e => e.Masp).HasColumnName("MASP");

                entity.Property(e => e.Banchay).HasColumnName("BANCHAY");

                entity.Property(e => e.Baohanh).HasColumnName("BAOHANH");

                entity.Property(e => e.Chitiet)
                    .HasColumnType("longtext")
                    .HasColumnName("CHITIET");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Giakm).HasColumnName("GIAKM");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(1000)
                    .HasColumnName("HINHANH");

                entity.Property(e => e.Luotxem).HasColumnName("LUOTXEM");

                entity.Property(e => e.Madm).HasColumnName("MADM");

                entity.Property(e => e.Mathuonghieu).HasColumnName("MATHUONGHIEU");

                entity.Property(e => e.Ngaydang).HasColumnName("NGAYDANG");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tensp)
                    .HasMaxLength(500)
                    .HasColumnName("TENSP");

                entity.Property(e => e.Tinhtrangsp)
                    .HasMaxLength(50)
                    .HasColumnName("TINHTRANGSP");

                entity.HasOne(d => d.MadmNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Madm)
                    .HasConstraintName("FK_PHANLOAIDANHMUC");

                entity.HasOne(d => d.MathuonghieuNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Mathuonghieu)
                    .HasConstraintName("FK_TRONG");
            });

            modelBuilder.Entity<Thuonghieu>(entity =>
            {
                entity.HasKey(e => e.Mathuonghieu)
                    .HasName("PRIMARY");

                entity.ToTable("thuonghieu");

                entity.Property(e => e.Mathuonghieu).HasColumnName("MATHUONGHIEU");

                entity.Property(e => e.Tenthuonghieu)
                    .HasMaxLength(150)
                    .HasColumnName("TENTHUONGHIEU");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.HasKey(e => e.Matintuc)
                    .HasName("PRIMARY");

                entity.ToTable("tintuc");

                entity.HasIndex(e => e.Manguoidung, "FK_DANGTIN");

                entity.Property(e => e.Matintuc).HasColumnName("MATINTUC");

                entity.Property(e => e.Hinhanh)
                    .HasMaxLength(1000)
                    .HasColumnName("HINHANH");

                entity.Property(e => e.Hot)
                    .HasColumnType("tinyint")
                    .HasColumnName("HOT");

                entity.Property(e => e.Manguoidung).HasColumnName("MANGUOIDUNG");

                entity.Property(e => e.Motangan)
                    .HasMaxLength(1000)
                    .HasColumnName("MOTANGAN");

                entity.Property(e => e.Ngaydang).HasColumnName("NGAYDANG");

                entity.Property(e => e.Ngaysua).HasColumnName("NGAYSUA");

                entity.Property(e => e.Noidung)
                    .HasColumnType("longtext")
                    .HasColumnName("NOIDUNG");

                entity.Property(e => e.Tieude)
                    .HasMaxLength(500)
                    .HasColumnName("TIEUDE");

                entity.HasOne(d => d.ManguoidungNavigation)
                    .WithMany(p => p.Tintucs)
                    .HasForeignKey(d => d.Manguoidung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DANGTIN");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.Idtransaction)
                    .HasName("PRIMARY");

                entity.ToTable("transaction");

                entity.Property(e => e.Idtransaction).HasColumnName("IDTRANSACTION");

                entity.Property(e => e.Mota)
                    .HasMaxLength(500)
                    .HasColumnName("MOTA");

                entity.Property(e => e.Tinhtrang)
                    .HasMaxLength(200)
                    .HasColumnName("TINHTRANG");
            });

            modelBuilder.Entity<Vaitronguoidung>(entity =>
            {
                entity.HasKey(e => e.Maquyen)
                    .HasName("PRIMARY");

                entity.ToTable("vaitronguoidung");

                entity.Property(e => e.Maquyen).HasColumnName("MAQUYEN");

                entity.Property(e => e.Tenquyen)
                    .HasMaxLength(250)
                    .HasColumnName("TENQUYEN");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.Mavoucher)
                    .HasName("PRIMARY");

                entity.ToTable("voucher");

                entity.Property(e => e.Mavoucher).HasColumnName("MAVOUCHER");

                entity.Property(e => e.Ngaybd).HasColumnName("NGAYBD");

                entity.Property(e => e.Ngaykt)
                    .HasColumnType("date")
                    .HasColumnName("NGAYKT");

                entity.Property(e => e.Tenma)
                    .HasMaxLength(50)
                    .HasColumnName("TENMA");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(250)
                    .HasColumnName("TRANGTHAI");

                entity.Property(e => e.Tyle).HasColumnName("TYLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

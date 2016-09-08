using System.ComponentModel.DataAnnotations.Schema;
using App.Core.Domain;

namespace App.Data.Mapping{
    public class ChatLieuMap : AppEntityTypeConfiguration<ChatLieu>{
        public ChatLieuMap(){
            ToTable("ChatLieu");
            HasKey(c => c.MaChatLieu);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class ChiTietHdbMap : AppEntityTypeConfiguration<ChiTietHDB>{
        public ChiTietHdbMap(){
            this.ToTable("ChiTietHDB")
                .HasKey(c => c.ID)
                .HasRequired(f => f.HoaDonBan);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class ChiTietHdnMap : AppEntityTypeConfiguration<ChiTietHDN>{
        public ChiTietHdnMap(){
            ToTable("ChiTietHDN").
                HasKey(c => c.ID).
                HasRequired(f => f.HoaDonNhap);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class CongViecMap : AppEntityTypeConfiguration<CongViec>{
        public CongViecMap(){
            ToTable("CongViec");
            HasKey(c => c.MaCV);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class DoiTuongMap : AppEntityTypeConfiguration<DoiTuong>{
        public DoiTuongMap(){
            ToTable("DoiTuong");
            HasKey(c => c.MaDoiTuong);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class HoaDonBanMap : AppEntityTypeConfiguration<HoaDonBan>{
        public HoaDonBanMap(){
            ToTable("HoaDonBan");
            HasKey(c => c.SoHDB);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class HoaDonNhapMap : AppEntityTypeConfiguration<HoaDonNhap>{
        public HoaDonNhapMap(){
            ToTable("HoaDonNhap");
            HasKey(c => c.SoHDN);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class KhachHangMap : AppEntityTypeConfiguration<KhachHang>{
        public KhachHangMap(){
            ToTable("KhachHang");
            HasKey(c => c.MaKhach);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class KichCoMap : AppEntityTypeConfiguration<KichCo>{
        public KichCoMap(){
            ToTable("KichCo");
            HasKey(c => c.MaCo);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class MauMap : AppEntityTypeConfiguration<Mau>{
        public MauMap(){
            ToTable("Mau");
            HasKey(c => c.MaMau);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class MuaMap : AppEntityTypeConfiguration<Mua>{
        public MuaMap(){
            ToTable("Mua");
            HasKey(c => c.MaMua);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class NhaCungCapMap : AppEntityTypeConfiguration<NhaCungCap>{
        public NhaCungCapMap(){
            ToTable("NhaCungCap");
            HasKey(c => c.MaNCC);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class NhanVienMap : AppEntityTypeConfiguration<NhanVien>{
        public NhanVienMap(){
            ToTable("NhanVien");
            HasKey(c => c.MaNhanVien);
        }
    }

    public class NuanXuatMap : AppEntityTypeConfiguration<NuocSanXuat>{
        public NuanXuatMap(){
            ToTable("NuanXuat");
            HasKey(c => c.MaNuocSX);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class SanPhamMap : AppEntityTypeConfiguration<SanPham>{
        public SanPhamMap(){
            ToTable("SanPham");
            HasKey(c => c.MaGiayDep);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }

    public class TheLoaiMap : AppEntityTypeConfiguration<TheLoai>{
        public TheLoaiMap(){
            ToTable("TheLoai");
            HasKey(c => c.MaLoai);
            Property(obj => obj.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("ID");
        }
    }
}
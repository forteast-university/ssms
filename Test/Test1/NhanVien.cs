//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test1
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanVien
    {
        public NhanVien()
        {
            this.HoaDonBan = new HashSet<HoaDonBan>();
            this.HoaDonNhap = new HashSet<HoaDonNhap>();
        }
    
        public int ID { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public string MaCV { get; set; }
        public string MatKhau { get; set; }
    
        public virtual CongViec CongViec { get; set; }
        public virtual ICollection<HoaDonBan> HoaDonBan { get; set; }
        public virtual ICollection<HoaDonNhap> HoaDonNhap { get; set; }
    }
}

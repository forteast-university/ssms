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
    
    public partial class CongViec
    {
        public CongViec()
        {
            this.NhanVien = new HashSet<NhanVien>();
        }
    
        public int ID { get; set; }
        public string MaCV { get; set; }
        public string TenCV { get; set; }
    
        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    public partial class Mua: BaseEntity
    {
        public Mua()
        {
            //this.SanPham = new HashSet<SanPham>();
        }
    
        //public int ID { get; set; }
        public string MaMua { get; set; }
        public string TenMua { get; set; }
    
        //public virtual ICollection<SanPham> SanPham { get; set; }
    }
}

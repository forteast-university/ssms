﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using App.Core.Domain;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace App.Core.Domain {



    public partial class ChatLieu: BaseEntity {
        public ChatLieu() {
            //this.SanPham = new HashSet<SanPham>();
        }

        //public int ID { get; set; }
        [Display(Name = "Mã chất liệu")]
        public string MaChatLieu { get; set; }
        [Display(Name = "Tên chất liệu")]
        public string TenChatLieu { get; set; }

        //public virtual ICollection<SanPham> SanPham { get; set; }
    }
}

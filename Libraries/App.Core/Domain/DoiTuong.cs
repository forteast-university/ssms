// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="DoiTuong.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class DoiTuong.
    /// </summary>
    public partial class DoiTuong: BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoiTuong"/> class.
        /// </summary>
        public DoiTuong()
        {
            //this.SanPham = new HashSet<SanPham>();
        }
    
        //public int ID { get; set; }
        /// <summary>
        /// Gets or sets the ma doi tuong.
        /// </summary>
        /// <value>The ma doi tuong.</value>
        public string MaDoiTuong { get; set; }
        /// <summary>
        /// Gets or sets the ten doi tuong.
        /// </summary>
        /// <value>The ten doi tuong.</value>
        public string TenDoiTuong { get; set; }
    
        //public virtual ICollection<SanPham> SanPham { get; set; }
    }
}

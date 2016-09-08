// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="TheLoai.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class TheLoai.
    /// </summary>
    public partial class TheLoai: BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TheLoai"/> class.
        /// </summary>
        public TheLoai()
        {
            //this.SanPham = new HashSet<SanPham>();
        }
    
        //public int ID { get; set; }
        /// <summary>
        /// Gets or sets the ma loai.
        /// </summary>
        /// <value>The ma loai.</value>
        public string MaLoai { get; set; }
        /// <summary>
        /// Gets or sets the ten loai.
        /// </summary>
        /// <value>The ten loai.</value>
        public string TenLoai { get; set; }
    
        //public virtual ICollection<SanPham> SanPham { get; set; }
    }
}

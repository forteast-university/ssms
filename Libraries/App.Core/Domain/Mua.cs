// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="Mua.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class Mua.
    /// </summary>
    public partial class Mua: BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mua"/> class.
        /// </summary>
        public Mua()
        {
            //this.SanPham = new HashSet<SanPham>();
        }
    
        //public int ID { get; set; }
        /// <summary>
        /// Gets or sets the ma mua.
        /// </summary>
        /// <value>The ma mua.</value>
        public string MaMua { get; set; }
        /// <summary>
        /// Gets or sets the ten mua.
        /// </summary>
        /// <value>The ten mua.</value>
        public string TenMua { get; set; }
    
        //public virtual ICollection<SanPham> SanPham { get; set; }
    }
}

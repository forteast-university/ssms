// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="Mau.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class Mau.
    /// </summary>
    public partial class Mau : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mau"/> class.
        /// </summary>
        public Mau()
        {
            //this.SanPham = new HashSet<SanPham>();
        }


        /// <summary>
        /// Gets or sets the ma mau.
        /// </summary>
        /// <value>The ma mau.</value>
        public string MaMau { get; set; }
        /// <summary>
        /// Gets or sets the ten mau.
        /// </summary>
        /// <value>The ten mau.</value>
        public string TenMau { get; set; }
    
        // public virtual ICollection<SanPham> SanPham { get; set; }
    }
}

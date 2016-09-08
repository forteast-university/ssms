// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="KichCo.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace App.Core.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class KichCo.
    /// </summary>
    public partial class KichCo: BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KichCo"/> class.
        /// </summary>
        public KichCo()
        {
            //this.SanPham = new HashSet<SanPham>();
        }
    
        //public int ID { get; set; }
        /// <summary>
        /// Gets or sets the ma co.
        /// </summary>
        /// <value>The ma co.</value>
        public string MaCo { get; set; }
        /// <summary>
        /// Gets or sets the ten co.
        /// </summary>
        /// <value>The ten co.</value>
        public string TenCo { get; set; }
    
        //public virtual ICollection<SanPham> SanPham { get; set; }
    }
}

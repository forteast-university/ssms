// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="CongViec.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;
namespace App.Core.Domain {
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class CongViec.
    /// </summary>
    public partial class CongViec: BaseEntity {
        /// <summary>
        /// Initializes a new instance of the <see cref="CongViec"/> class.
        /// </summary>
        public CongViec() {
            //this.NhanVien = new HashSet<NhanVien>();
        }


        /// <summary>
        /// Gets or sets the ma cv.
        /// </summary>
        /// <value>The ma cv.</value>
        [DisplayName("Mã công việc")]
        public string MaCV { get; set; }
        /// <summary>
        /// Gets or sets the ten cv.
        /// </summary>
        /// <value>The ten cv.</value>
        [DisplayName("Tên công việc")]
        public string TenCV { get; set; }

        // public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}

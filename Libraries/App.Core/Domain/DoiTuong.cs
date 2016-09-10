// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="DoiTuong.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;

namespace App.Core.Domain
{
    /// <summary>
    ///     Class DoiTuong.
    /// </summary>
    public class DoiTuong : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the ma doi tuong.
        /// </summary>
        /// <value>The ma doi tuong.</value>
        [DisplayName("Mã đối tượng")]
        public string MaDoiTuong { get; set; }

        /// <summary>
        ///     Gets or sets the ten doi tuong.
        /// </summary>
        /// <value>The ten doi tuong.</value>
        [DisplayName("Tên đối tượng")]
        public string TenDoiTuong { get; set; }
    }
}
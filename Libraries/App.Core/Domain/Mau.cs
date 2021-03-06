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

using System.ComponentModel;

namespace App.Core.Domain
{
    /// <summary>
    ///     Class Mau.
    /// </summary>
    public class Mau : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the ma mau.
        /// </summary>
        /// <value>The ma mau.</value>
        [DisplayName("Mã màu")]
        public string MaMau { get; set; }

        /// <summary>
        ///     Gets or sets the ten mau.
        /// </summary>
        /// <value>The ten mau.</value>
        [DisplayName("Tên màu")]
        public string TenMau { get; set; }
    }
}
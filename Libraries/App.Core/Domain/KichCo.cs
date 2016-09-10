// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="KichCo.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;

namespace App.Core.Domain
{
    /// <summary>
    ///     Class KichCo.
    /// </summary>
    public class KichCo : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the ma co.
        /// </summary>
        /// <value>The ma co.</value>
        [DisplayName("Mã cỡ")]
        public string MaCo { get; set; }

        /// <summary>
        ///     Gets or sets the ten co.
        /// </summary>
        /// <value>The ten co.</value>
        [DisplayName("Tên cỡ")]
        public string TenCo { get; set; }
    }
}
// ***********************************************************************
// Assembly         : App.Core
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="ChatLieu.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.ComponentModel;

namespace App.Core.Domain
{
    /// <summary>
    ///     Class ChatLieu.
    /// </summary>
    public class ChatLieu : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the ma chat lieu.
        /// </summary>
        /// <value>The ma chat lieu.</value>
        [DisplayName("Mã chất liệu")]
        public string MaChatLieu { get; set; }

        /// <summary>
        ///     Gets or sets the ten chat lieu.
        /// </summary>
        /// <value>The ten chat lieu.</value>
        [DisplayName("Tên chất liệu")]
        public string TenChatLieu { get; set; }
    }
}
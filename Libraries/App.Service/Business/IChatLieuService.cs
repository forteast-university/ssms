// ***********************************************************************
// Assembly         : App.Service
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="IChatLieuService.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using App.Core.Domain;

namespace App.Service.Business
{
    /// <summary>
    /// Interface IChatLieuService
    /// </summary>
    public interface IChatLieuService : ICommonService<ChatLieu>
    {
        /// <summary>
        /// Gets the chat lieu by team.
        /// </summary>
        /// <param name="maChatLieu">The ma chat lieu.</param>
        /// <returns>List&lt;ChatLieu&gt;.</returns>
        List<ChatLieu> GetChatLieuByTeam(string maChatLieu);
    }
}
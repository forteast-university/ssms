// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-08-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-08-2016
// ***********************************************************************
// <copyright file="IChatLieuController.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using App.Core.Domain;
using App.Models;

namespace App.Controllers{
    /// <summary>
    /// Interface IChatLieuController
    /// </summary>
    public interface IChatLieuController : IBaseController<ChatLieuModel> {

        IList<ChatLieuModel> Get(string value);
    }
}
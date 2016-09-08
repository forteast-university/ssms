// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-07-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="ProductModel.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using App.Core.Domain;

namespace App.Models
{
    /// <summary>
    /// Class ProductModel.
    /// </summary>
    //[NotMapped]
    public class ChatLieuModel: ChatLieu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatLieuModel" /> class.
        /// </summary>
        public ChatLieuModel()
        {
            
        
        }

    }
}
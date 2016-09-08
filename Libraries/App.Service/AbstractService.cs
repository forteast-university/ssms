// ***********************************************************************
// Assembly         : App.Business
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="AbstractService.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using App.Core.Data;
using App.Core.Domain;
using App.Data;

namespace App.Service {


    /// <summary>
    /// Class ProductBusiness.
    /// </summary>
    abstract public class AbstractService
    {
        /// <summary>
        /// The data
        /// </summary>
        protected IDataProvider data;
        /// <summary>
        /// The database
        /// </summary>
        protected IDbContext db;
        
    }
}

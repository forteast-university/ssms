// ***********************************************************************
// Assembly         : App.Data
// Author           : Duc Huynh
// Created          : 07-28-2016
//
// Last Modified By : Duc Huynh
// Last Modified On : 07-28-2016
// ***********************************************************************
// <copyright file="SearchOptionalList.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace ADA.Core.Utility {

    /// <summary>
    /// Class SearchOptionalList.
    /// </summary>
    public class SearchOptionalList {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the selected.
        /// </summary>
        /// <value>The selected.</value>
        public bool Selected { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
    }
}

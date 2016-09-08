// ***********************************************************************
// Assembly         : App.Framework
// Author           : Hung Le
// Created          : 08-18-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="ResponseJson.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace App.Core.Response
{
    /// <summary>
    /// Class ResponseJson.
    /// </summary>
    /// <remarks>odcup.com</remarks>
    public class ResponseJson
    {
        /// <summary>
        /// Gets or sets the success.
        /// </summary>
        /// <value>The success.</value>
        /// <remarks>odcup.com</remarks>
        public int success { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        /// <remarks>odcup.com</remarks>
        public string message { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        /// <remarks>odcup.com</remarks>
        public object data { get; set; }
        /// <summary>
        /// Errors the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="errNum">The error number.</param>
        /// <param name="data">The data.</param>
        /// <returns>ResponseJson.</returns>
        /// <remarks>odcup.com</remarks>
        public static ResponseJson Error(string msg,int errNum=-1,object data=null)
        {
            return new ResponseJson
            {
                success=errNum,
                message = msg,
                data=data
            };
            
        }
        /// <summary>
        /// Successes the specified MSG.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="data">The data.</param>
        /// <returns>ResponseJson.</returns>
        /// <remarks>odcup.com</remarks>
        public static ResponseJson Success(string msg,object data=null)
        {
            return new ResponseJson
            {
                success = 1,
                message = msg,
                data=data
            };

        }
    }
}

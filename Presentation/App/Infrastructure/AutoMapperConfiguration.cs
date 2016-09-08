// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 08-29-2016
//
// Last Modified By : Hung Le
// Last Modified On : 08-29-2016
// ***********************************************************************
// <copyright file="AutoMapperConfiguration.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using App.Core.Domain;
using AutoMapper;
using App.Models;

namespace App.Infrastructure {
    /// <summary>
    /// Class AutoMapperConfiguration.
    /// </summary>
    public class AutoMapperConfiguration {
        /// <summary>
        /// The _mapper configuration
        /// </summary>
        //private static MapperConfiguration mapperConfiguration;
        /// <summary>
        /// The _mapper
        /// </summary>
        //private static IMapper mapper;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Init() {

            
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ChatLieuModel, ChatLieu>();
                cfg.CreateMap<ChatLieu, ChatLieuModel>();
            });

            //mapperConfiguration = new MapperConfiguration(c => {

            //    #region ProductApplicationModel, ProductApplication
            //    c.CreateMap<ChatLieuModel, ChatLieu>()
            //        //.ForMember(a => a.ID, b => b.Ignore())
            //        ;
            //    c.CreateMap<ChatLieu, ChatLieuModel>()
            //        //.ForMember(a => a.ID, b => b.Ignore())
            //        ;
            //    #endregion
            //});
            //mapper = mapperConfiguration.CreateMapper();
        }
        ///// <summary>
        ///// Mapper
        ///// </summary>
        ///// <value>The mapper.</value>
        //public static IMapper Mapper {
        //    get {
        //        return mapper;
        //    }
        //}
        ///// <summary>
        ///// Mapper configuration
        ///// </summary>
        ///// <value>The mapper configuration.</value>
        //public static MapperConfiguration MapperConfiguration {
        //    get {
        //        return mapperConfiguration;
        //    }
        //}
    }
}
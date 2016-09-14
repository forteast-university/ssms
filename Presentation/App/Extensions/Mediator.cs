// ***********************************************************************
// Assembly         : App
// Author           : Hung Le
// Created          : 09-09-2016
//
// Last Modified By : Hung Le
// Last Modified On : 09-09-2016
// ***********************************************************************
// <copyright file="AppMediatorEvent.cs" company="Thanh Dong University">
//     Copyright (c) Thanh Dong University. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Extensions {
    /// <summary>
    /// Class AppMediatorEvent.
    /// </summary>
    public class Mediator{
        public static string DANGNHAP_THANH_CONG = "DANG_NHAP_THANH_CONG";
        public static string DANGNHAP_KHONG_THANH_CONG = "DANG_NHAP_KHONG_THANH_CONG";
        public static string NHAN_VIEN_CALL_CONG_VIEC_GET_MA = "NHAN_VIEN_CALL_CONG_VIEC_GET_MA";
        
        public static string SAN_PHAM_CALL_THE_LOAI_GET_MA = "SAN_PHAM_CALL_THELOAI_GET_MA";
        public static string SAN_PHAM_CALL_KICH_CO_GET_MA = "SAN_PHAM_CALL_KICHCO_GET_MA";
        public static string SAN_PHAM_CALL_CHAT_LIEU_GET_MA = "SAN_PHAM_CALL_CHATLIEU_GET_MA";
        public static string SAN_PHAM_CALL_MAU_GET_MA = "SAN_PHAM_CALL_MAU_GET_MA";
        public static string SAN_PHAM_CALL_DOI_TUONG_GET_MA = "SAN_PHAM_CALL_DOITUONG_GET_MA";
        public static string SAN_PHAM_CALL_MUA_GET_MA = "SAN_PHAM_CALL_MUA_GET_MA";
        public static string SAN_PHAM_CALL_NUOC_SANXUAT_GET_MA = "SAN_PHAM_CALL_NUOCSANXUAT_GET_MA";

        public static string HOA_DON_NHAP_CALL_SAM_PHAM_GET_SANPHAM = "HOA_DON_NHAP_CALL_SAM_PHAM_GET_SANPHAM";
        public static string HOA_DON_NHAP_CANCEL_SAM_PHAM_GET_SANPHAM = "HOA_DON_NHAP_CANCEL_SAM_PHAM_GET_SANPHAM";

        public static string HOA_DON_BAN_CALL_SAM_PHAM_GET_SANPHAM = "HOA_DON_BAN_CALL_SAM_PHAM_GET_SANPHAM";
        public static string HOA_DON_BAN_CANCEL_SAM_PHAM_GET_SANPHAM = "HOA_DON_BAN_CANCEL_SAM_PHAM_GET_SANPHAM";

    }

    public class AppEvent<T> : EventArgs{

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// 
        public T value{
            get;
            set;
        }
        public string Name {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address {
            get;
            set;
        }
    }
}

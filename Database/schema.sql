USE MASTER
-- ***********************************************************************
-- Project          : SSMS
-- Author           : Nam Nguyen, Cang Nguyen
-- Created          : 08-28-2016
--
-- Last Modified By : Hung Le
-- Last Modified On : 09-06-2016
-- ***********************************************************************
-- <copyright file="schema.sql" organize="Thanh Dong University">
--     Copyright (c) Thanh Dong University. All rights reserved.
-- </copyright>
-- <summary>
--	Shoes Shopping Managerment System
--  Account for initializing as: ssms/ssms@123 
-- </summary>
-- ***********************************************************************
IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'ssms')
	DROP DATABASE ssms
GO

IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name = N'ssms')
	CREATE DATABASE ssms
GO

USE ssms
GO

CREATE TABLE TheLoai(
	ID int IDENTITY(1,1) NOT NULL,
	MaLoai varchar(50) NOT NULL,
	TenLoai nvarchar(50) NULL,
	CONSTRAINT PK_TheLoai PRIMARY KEY CLUSTERED(MaLoai ASC)
) 
GO

CREATE TABLE KichCo(
	ID int IDENTITY(1,1) NOT NULL,
	MaCo varchar(50) NOT NULL,
	TenCo nvarchar(50) NULL,
	CONSTRAINT PK_Co PRIMARY KEY CLUSTERED(MaCo ASC)
) 
GO

CREATE TABLE ChatLieu(
	ID int IDENTITY(1,1) NOT NULL,
	MaChatLieu varchar(50) NOT NULL,
	TenChatLieu nvarchar(50) NULL,
	CONSTRAINT PK_ChatLieu PRIMARY KEY CLUSTERED(MaChatLieu ASC)
) 
GO

CREATE TABLE Mau(
	ID int IDENTITY(1,1) NOT NULL,
	MaMau varchar(50) NOT NULL,
	TenMau nvarchar(50) NULL,
	CONSTRAINT PK_Mau PRIMARY KEY CLUSTERED(MaMau ASC)
) 
GO

CREATE TABLE Mua(
	ID int IDENTITY(1,1) NOT NULL,
	MaMua varchar(50) NOT NULL,
	TenMua nvarchar(50) NULL,
	CONSTRAINT PK_Mua PRIMARY KEY CLUSTERED(MaMua ASC)
) 
GO

CREATE TABLE CongViec(
	ID int IDENTITY(1,1) NOT NULL,
	MaCV varchar(50) NOT NULL,
	TenCV nvarchar(50) NULL,
	CONSTRAINT PK_CongViec PRIMARY KEY CLUSTERED(MaCV ASC)
) 
GO

CREATE TABLE KhachHang(
	ID int IDENTITY(1,1) NOT NULL,
	MaKhach varchar(50) NOT NULL,
	TenKhach nvarchar(50) NULL,
	DiaChi nvarchar(150) NULL,
	DienThoai varchar(50) NULL,
	CONSTRAINT PK_KhachHang PRIMARY KEY CLUSTERED(MaKhach ASC)
) 
GO

CREATE TABLE NuocSanXuat(
	ID int IDENTITY(1,1) NOT NULL,
	MaNuocSX varchar(50) NOT NULL,
	TenNuocSX nvarchar(50) NULL,
	CONSTRAINT PK_NuocSanXuat PRIMARY KEY CLUSTERED(MaNuocSX ASC)
) 
GO

CREATE TABLE NhaCungCap(
	ID int IDENTITY(1,1) NOT NULL,
	MaNCC varchar(50) NOT NULL,
	TenNCC nvarchar(50) NULL,
	DiaChi nvarchar(150) NULL,
	DienThoai varchar(50) NULL,
	CONSTRAINT PK_NhaCungCap PRIMARY KEY CLUSTERED(MaNCC ASC)
) 
GO

CREATE TABLE DoiTuong(
	ID int IDENTITY(1,1) NOT NULL,
	MaDoiTuong varchar(50) NOT NULL,
	TenDoiTuong nvarchar(50) NULL,
	CONSTRAINT PK_DoiTuong PRIMARY KEY CLUSTERED(MaDoiTuong ASC)
) 
GO

CREATE TABLE SanPham(
	ID int IDENTITY(1,1) NOT NULL,
	MaGiayDep varchar(50) NOT NULL,
	TenGiayDep nvarchar(50) NULL,
	MaLoai varchar(50) NULL,
	MaCo varchar(50) NULL,
	MaChatLieu varchar(50) NULL,
	MaMau varchar(50) NULL,
	MaDoiTuong varchar(50) NULL,
	MaMua varchar(50) NULL,
	MaNuocSX varchar(50) NULL,
	SoLuong int NULL,
	Anh nvarchar(300) NULL,
	DonGiaNhap decimal(18, 2) NULL,
	DonGiaBan decimal(18, 2) NULL,
	CONSTRAINT PK_SanPham PRIMARY KEY CLUSTERED(MaGiayDep ASC)
) 
GO

CREATE TABLE HoaDonBan(
	ID int IDENTITY(1,1) NOT NULL,
	SoHDB varchar(50) NOT NULL,
	MaNV varchar(50) NULL,
	NgayBan datetime NULL,
	MaKhach varchar(50) NULL,
	TongTien decimal(18, 2) NULL,
	CONSTRAINT PK_HoaDonBan PRIMARY KEY CLUSTERED(SoHDB ASC)
) 
GO

CREATE TABLE HoaDonNhap(
	ID int IDENTITY(1,1) NOT NULL,
	SoHDN varchar(50) NOT NULL,
	MaNV varchar(50) NULL,
	NgayNhap datetime NULL,
	MaNCC varchar(50) NULL,
	TongTien decimal(18, 2) NULL,
	CONSTRAINT PK_HoaDonNha PRIMARY KEY CLUSTERED(SoHDN ASC)
) 
GO

CREATE TABLE NhanVien(
	ID int IDENTITY(1,1) NOT NULL,
	MaNhanVien varchar(50) NOT NULL,
	TenNhanVien nvarchar(50) NULL,
	GioiTinh nvarchar(50) NULL,
	NgaySinh datetime NULL,
	DienThoai varchar(50) NULL,
	DiaChi nvarchar(150) NULL,
	MaCV varchar(50) NULL,
	MatKhau nvarchar(50) NULL,
	CONSTRAINT PK_NhanVien PRIMARY KEY CLUSTERED(MaNhanVien ASC)
) 
GO

CREATE TABLE ChiTietHDB(
	ID int IDENTITY(1,1) NOT NULL,
	MaGiayDep varchar(50) NULL,
	SoLuong int NULL,
	GiamGia nvarchar(50) NULL,
	ThanhTien nvarchar(50) NULL,
	SoHDB varchar(50)
) 
GO

CREATE TABLE ChiTietHDN(
	ID int IDENTITY(1,1) NOT NULL ,
	SoHDN varchar(50),
	MaGiayDep varchar(50) NULL,
	SoLuong int NULL,
	DonGia decimal(18, 2) NULL,
	GiamGia varchar(50) NULL,
	ThanhTien decimal(18, 2) NULL
) 
GO

ALTER TABLE SanPham  WITH CHECK ADD  CONSTRAINT FK_SanPham_ChatLieu FOREIGN KEY(MaChatLieu)
	REFERENCES ChatLieu (MaChatLieu)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE SanPham CHECK CONSTRAINT FK_SanPham_ChatLieu
GO


ALTER TABLE SanPham  WITH CHECK ADD  CONSTRAINT FK_SanPham_DoiTuong FOREIGN KEY(MaDoiTuong)
	REFERENCES DoiTuong (MaDoiTuong)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE SanPham CHECK CONSTRAINT FK_SanPham_DoiTuong
GO


ALTER TABLE SanPham  WITH CHECK ADD  CONSTRAINT FK_SanPham_KichCo FOREIGN KEY(MaCo)
	REFERENCES KichCo (MaCo)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE SanPham CHECK CONSTRAINT FK_SanPham_KichCo


GO
ALTER TABLE SanPham  WITH CHECK ADD  CONSTRAINT FK_SanPham_Mau FOREIGN KEY(MaMau)
	REFERENCES Mau (MaMau)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE SanPham CHECK CONSTRAINT FK_SanPham_Mau


GO
ALTER TABLE SanPham  WITH CHECK ADD  CONSTRAINT FK_SanPham_Mua FOREIGN KEY(MaMua)
	REFERENCES Mua (MaMua)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE SanPham CHECK CONSTRAINT FK_SanPham_Mua


GO
ALTER TABLE SanPham  WITH CHECK ADD  CONSTRAINT FK_SanPham_NuocSanXuat FOREIGN KEY(MaNuocSX)
	REFERENCES NuocSanXuat (MaNuocSX)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE SanPham CHECK CONSTRAINT FK_SanPham_NuocSanXuat


GO
ALTER TABLE SanPham  WITH CHECK ADD  CONSTRAINT FK_SanPham_TheLoai FOREIGN KEY(MaLoai)
	REFERENCES TheLoai (MaLoai)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE SanPham CHECK CONSTRAINT FK_SanPham_TheLoai


GO
ALTER TABLE HoaDonBan  WITH CHECK ADD  CONSTRAINT FK_HoaDonBan_KhachHang FOREIGN KEY(MaKhach)
	REFERENCES KhachHang (MaKhach)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE HoaDonBan CHECK CONSTRAINT FK_HoaDonBan_KhachHang


GO
ALTER TABLE HoaDonBan  WITH CHECK ADD  CONSTRAINT FK_HoaDonBan_NhanVien FOREIGN KEY(MaNV)
	REFERENCES NhanVien (MaNhanVien)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE HoaDonBan CHECK CONSTRAINT FK_HoaDonBan_NhanVien


GO
ALTER TABLE HoaDonNhap  WITH CHECK ADD  CONSTRAINT FK_HoaDonNhap_NhaCungCap FOREIGN KEY(MaNCC)
	REFERENCES NhaCungCap (MaNCC)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE HoaDonNhap CHECK CONSTRAINT FK_HoaDonNhap_NhaCungCap


GO
ALTER TABLE HoaDonNhap  WITH CHECK ADD  CONSTRAINT FK_HoaDonNhap_NhanVien FOREIGN KEY(MaNV)
	REFERENCES NhanVien (MaNhanVien)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE HoaDonNhap CHECK CONSTRAINT FK_HoaDonNhap_NhanVien


GO
ALTER TABLE NhanVien  WITH CHECK ADD  CONSTRAINT FK_NhanVien_CongViec FOREIGN KEY(MaCV)
	REFERENCES CongViec (MaCV)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE NhanVien CHECK CONSTRAINT FK_NhanVien_CongViec


GO
ALTER TABLE ChiTietHDB  WITH CHECK ADD  CONSTRAINT FK_ChiTietHDB_HoaDonBan FOREIGN KEY(SoHDB)
	REFERENCES HoaDonBan (SoHDB)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE ChiTietHDB CHECK CONSTRAINT FK_ChiTietHDB_HoaDonBan


GO
ALTER TABLE ChiTietHDB  WITH CHECK ADD  CONSTRAINT FK_ChiTietHDB_SanPham FOREIGN KEY(MaGiayDep)
	REFERENCES SanPham (MaGiayDep)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE ChiTietHDB CHECK CONSTRAINT FK_ChiTietHDB_SanPham


GO
ALTER TABLE ChiTietHDN  WITH CHECK ADD  CONSTRAINT FK_ChiTietHDN_HoaDonNhap FOREIGN KEY(SoHDN)
	REFERENCES HoaDonNhap (SoHDN)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE ChiTietHDN CHECK CONSTRAINT FK_ChiTietHDN_HoaDonNhap
GO

ALTER TABLE ChiTietHDN  WITH CHECK ADD  CONSTRAINT FK_ChiTietHDN_SanPham FOREIGN KEY(MaGiayDep)
	REFERENCES SanPham (MaGiayDep)
	ON UPDATE CASCADE
	ON DELETE CASCADE
GO
ALTER TABLE ChiTietHDN CHECK CONSTRAINT FK_ChiTietHDN_SanPham
GO

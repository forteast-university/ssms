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
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaLoai varchar(50) unique NOT NULL,
	TenLoai nvarchar(50) NULL,
) 
GO

CREATE TABLE KichCo(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaCo varchar(50) NOT NULL,
	TenCo nvarchar(50) NULL
) 
GO

CREATE TABLE ChatLieu(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaChatLieu varchar(50) unique NOT NULL,
	TenChatLieu nvarchar(50) NULL
) 
GO

CREATE TABLE Mau(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaMau varchar(50) unique NOT NULL,
	TenMau nvarchar(50) NULL
) 
GO

CREATE TABLE Mua(
	ID int IDENTITY(1,1) PRIMARY KEY  NOT NULL,
	MaMua varchar(50) unique NOT NULL,
	TenMua nvarchar(50) NULL
) 
GO

CREATE TABLE CongViec(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaCV varchar(50) unique NOT NULL,
	TenCV nvarchar(50) NULL
) 
GO

CREATE TABLE KhachHang(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaKhach varchar(50) unique NOT NULL,
	TenKhach nvarchar(50) NULL,
	DiaChi nvarchar(150) NULL,
	DienThoai varchar(50) NULL
) 
GO

CREATE TABLE NuocSanXuat(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaNuocSX varchar(50) unique NOT NULL,
	TenNuocSX nvarchar(50) NULL
) 
GO

CREATE TABLE NhaCungCap(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaNCC varchar(50) unique NOT NULL,
	TenNCC nvarchar(50) NULL,
	DiaChi nvarchar(150) NULL,
	DienThoai varchar(50) NULL
) 
GO

CREATE TABLE DoiTuong(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaDoiTuong varchar(50)  unique NOT NULL,
	TenDoiTuong nvarchar(50) NULL,
) 
GO

CREATE TABLE SanPham(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaGiayDep varchar(50) unique NOT NULL,
	TenGiayDep nvarchar(50) NULL,
	SoLuong int NULL,
	Anh nvarchar(300) NULL,
	DonGiaNhap decimal(18, 2) NULL,
	DonGiaBan decimal(18, 2) NULL,

	MaLoai varchar(50) NULL,
	MaCo varchar(50) NULL,
	MaChatLieu varchar(50) NULL,
	MaMau varchar(50) NULL,
	MaDoiTuong varchar(50) NULL,
	MaMua varchar(50) NULL,
	MaNuocSX varchar(50) NULL,
	
	--update
	TheLoaiID int null,
	KichCoID int null,
	ChatLieuID int null,
	MauID int null,
	DoiTuongID int null,
	MuaID int null,
	NuocSanXuatID int null
	
	FOREIGN KEY(TheLoaiID) REFERENCES TheLoai (ID),
	FOREIGN KEY(KichCoID) REFERENCES KichCo (ID),
	FOREIGN KEY(ChatLieuID) REFERENCES ChatLieu (ID),
	FOREIGN KEY(MauID) REFERENCES Mau (ID),
	FOREIGN KEY(DoiTuongID) REFERENCES DoiTuong (ID),
	FOREIGN KEY(MuaID) REFERENCES Mua (ID),
	FOREIGN KEY(NuocSanXuatID) REFERENCES NuocSanXuat (ID)
) 
GO

CREATE TABLE NhanVien(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MaNhanVien varchar(50) unique NOT NULL,
	TenNhanVien nvarchar(50) NULL,
	GioiTinh nvarchar(50) NULL,
	NgaySinh datetime NULL,
	DienThoai varchar(50) NULL,
	DiaChi nvarchar(150) NULL,
	MatKhau nvarchar(50) NULL,

	MaCV varchar(50) NULL,
	--update
	CongViecID int NULL,
	FOREIGN KEY(CongViecID) REFERENCES CongViec(ID)
) 
GO
CREATE TABLE HoaDonBan(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	SoHDB varchar(50) NOT NULL,
	NgayBan datetime NULL,
	TongTien decimal(18, 2) NULL,
	MaNV varchar(50) NULL,
	MaKhach varchar(50) NULL,
	--update
	KhachHangID int NULL,
	NhanVienID int NULL,
	FOREIGN KEY(KhachHangID) REFERENCES KhachHang(ID), --ON UPDATE CASCADE ON DELETE CASCADE
	FOREIGN KEY(NhanVienID) REFERENCES NhanVien(ID)	   --ON UPDATE CASCADE ON DELETE CASCADE
) 
GO

CREATE TABLE ChiTietHDB(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	SoLuong int NULL,
	DonGia decimal(18, 2) NULL,
	GiamGia decimal(18, 2) NULL,
	ThanhTien decimal(18, 2) NULL,
	MaGiayDep varchar(50) NULL,
	SoHDB varchar(50),

	--update
	SanPhamID int NULL,
	HoaDonBanID int NULL,
	FOREIGN KEY(SanPhamID) REFERENCES SanPham(ID),
	FOREIGN KEY(HoaDonBanID) REFERENCES HoaDonBan(ID)
) 
GO

CREATE TABLE HoaDonNhap(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	SoHDN varchar(50) NOT NULL,
	NgayNhap datetime NULL,	
	TongTien decimal(18, 2) NULL,
		
	MaNV varchar(50) NULL,
	MaNCC varchar(50) NULL,
	--update
	NhanVienID int null,
	NhaCungCapID int null,
	FOREIGN KEY(NhanVienID) REFERENCES NhanVien(ID),
	FOREIGN KEY(NhaCungCapID) REFERENCES NhaCungCap(ID)
) 
GO

CREATE TABLE ChiTietHDN(
	ID int IDENTITY(1,1) NOT NULL ,
	SoLuong int NULL,
	DonGia decimal(18, 2) NOT NULL,
	GiamGia decimal(18, 2) NOT NULL,
	ThanhTien decimal(18, 2) NOT NULL,
	
	SoHDN varchar(50),
	MaGiayDep varchar(50) NOT NULL,
	--update
	SanPhamID int NOT NULL,
	HoaDonNhapID int NOT NULL,
	FOREIGN KEY(SanPhamID) REFERENCES SanPham(ID),
	FOREIGN KEY(HoaDonNhapID) REFERENCES HoaDonNhap(ID)
) 
GO
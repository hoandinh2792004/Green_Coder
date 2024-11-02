

create database Green_Coder
use Green_Coder

create table SanPham(
    ID int primary key, 
	TenSanPham nvarchar(50) not null , 
	SoLuong int not null, 
	TinhTrang nvarchar(50) , 
	DanhMuc nvarchar(50),
	NhaCungCap nvarchar(50), 
	GiaBan int not null, 
	GiaVon int , 
	AnhSanPham image, 
	MoTa ntext, 
)

ALTER TABLE SanPham
ALTER COLUMN AnhSanPham nvarchar;


create table DonHang(
  ID int IDENTITY(1,1) primary key, 
  TenKhachHang nvarchar(50), 
  SDT int,
  DiaChi nvarchar(50), 
  TenNguoiBan nvarchar(50), 
  SoHieuNguoiBan nvarchar(50) , 
  NgayBan datetime, 
  TenSanPham nvarchar(50), 
  MaSanPham int, 
  foreign key (MaSanPham) references dbo.SanPham(ID), 
  SoLuong int, 
  TinhTrang nvarchar(50), 
  GhiChu ntext, 

)

create table KhachHang(
  ID int identity(1,1) primary key, 
  TenKhachHang nvarchar(50), 
  SDT int, 
  DiaChi nvarchar(50),
  NgaySinh datetime, 
  IdTaiKhoan int, 
  foreign key (IdTaiKhoan) references dbo.TaiKhoan(ID) ,
)

ALTER TABLE DonHang
ADD IDKhachHang int;

ALTER TABLE DonHang
ADD CONSTRAINT FK_DonHang_KhachHang
FOREIGN KEY (IDKhachHang) REFERENCES KhachHang(ID);


create table TaiKhoan (
 ID int identity (1,1) primary key, 
 Email nvarchar(50) , 
 Pass nvarchar(50), 
)

create table TuThien(
  ID int identity (1,1) primary key ,
  IdKhachHang int, 
  foreign key (IdKhachHang) references dbo.KhachHang(ID),
  SoTien int, 
)

create table DanhMuc(
	ID int identity (1,1) primary key, 
	Ten nvarchar, 
	IdSanPham int, 
	foreign key (IdSanPham) references dbo.SanPham(ID),
)

select * from SanPham

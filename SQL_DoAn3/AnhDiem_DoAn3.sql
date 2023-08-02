create database DoGia_DoAn3
go
use DoGia_DoAn3
go


--Loại Sản Phẩm
create table LoaiSP
(
	MaLoai nvarchar(10) primary key,
	TenLoai nvarchar(max),
	GhiChu nvarchar(50)
)
go

--Hãng Sản phẩm
create table HangSP
(
	MaHang nvarchar(10) primary key,
	TenHang nvarchar(max),
	GhiChu nvarchar(50)
)
go

--Sản phẩm
create table SanPham
(
	MaSP nvarchar(10) primary key,
	TenSP nvarchar(max),
	MoTa nvarchar(max),
	Ram nvarchar(10),
	Rom nvarchar(10),
	SoLuong int,
	DonGia float,
	MaLoai nvarchar(10) foreign key references LoaiSP(MaLoai) on delete cascade on update cascade,
	MaHang nvarchar(10) foreign key references HangSP(MaHang) on delete cascade on update cascade,
	Anh nvarchar(50)
)
go

--Nhà cung cấp
create table NhaCungCap
(
	MaNCC nvarchar(10) primary key,
	TenNCC nvarchar(max),
	DiaChi nvarchar(max),
	SDT nvarchar(10)
)
go

--Khách hàng
create table KhachHang
(
	MaKH nvarchar(10) primary key,
	TenKh nvarchar(max),
	DiaChi nvarchar(max),
	SDT nvarchar(10)
)
go

--Nhân viên
create table NhanVien
(
	MaNV nvarchar(10) primary key,
	TenNV nvarchar(max),
	DiaChi nvarchar(max),
	SDT nvarchar(10),
	 Anh nvarchar(100)
)
go

create table HoaDonNhap
(
	MaHDN nvarchar(10) primary key,
	NgayNhap date,
	MaNV nvarchar(10)foreign key references NhanVien(MaNV) on delete cascade on update cascade,
	MaNCC nvarchar(10) foreign key references NhaCungCap(MaNCC) on delete cascade on update cascade,
	TongTien float
)
go

--Chi tiết hóa đơn nhập
create table CTHoaDonNhap
(
	MaHDN nvarchar(10) foreign key references HoaDonNhap(MaHDN) on delete cascade on update cascade,
	MaSP nvarchar(10) foreign key references SanPham(MaSP) on delete cascade on update cascade,
	primary key(MaHDN, MaSP),
	SoLuong int,
	GiaNhap float
)
go

--Đặt hàng
create table DatHang
(
	MaDH int primary key,
	MaKH nvarchar(10)foreign key references KhachHang(MaKH) on delete cascade on update cascade,
	HoTen nvarchar(max),
	Email nvarchar(50),
	Phone nvarchar(10),
	DiaChi nvarchar(max),
	NgayDat date,
	TongTien float
)
go

--Chi tiết đặt hàng
create table CTDatHang
(
	MaDH int foreign key references DatHang(MaDH) on delete cascade on update cascade,
	MaSP nvarchar(10)foreign key references SanPham(MaSP) on delete cascade on update cascade,
	primary key(MaDH, MaSP),
	TenSP nvarchar(10),
	Anh nvarchar(50),
	SoLuong int,
	Gia float,
	GiamGia float,
	TongTien float
)
go

--Hóa đơn bán
create table HoaDonBan
(
	MaHDB nvarchar(10) primary key,
	NgayBan date,
	MaNV nvarchar(10)foreign key references NhanVien(MaNV) on delete cascade on update cascade,
	MaKH nvarchar(10)foreign key references KhachHang(MaKH) on delete cascade on update cascade,
	TongTien float
)
go

--Chi tiết hóa đơn bán
create table CTHoaDonBan
(
	MaHDB nvarchar(10) foreign key references HoaDonBan(MaHDB) on delete cascade on update cascade,
	MaSP nvarchar(10)foreign key references SanPham(MaSP) on delete cascade on update cascade,
	primary key(MaHDB, MaSP),
	SoLuong int,
	DonGia float,
	GiamGia float,
	ThanhTien float
)
go

--Tin tức
create table TinTuc
(
	MaTT nvarchar(10) primary key,
	TieuDe nvarchar(max),
	NoiDung nvarchar(max),
	NgayDang date,
	MaNV nvarchar(10)foreign key references NhanVien(MaNV) on delete cascade on update cascade,
	Anh nvarchar(50),
)
go

--Quản trị
create table QuanTri
(
	UserName nvarchar(15) primary key,
	Pass nvarchar(20) not null,
)
go

--Người dùng
create table NguoiDung
(
	UserName nvarchar(15) primary key,
	Pass nvarchar(20) not null,
)
go

create function func_nextID( @lastUserID nvarchar(10), @prefix nvarchar(3), @size int)
	returns nvarchar(10)
as
	begin
		if(@lastUserID ='')
			set @lastUserID = @prefix + REPLICATE(0,@size - LEN(@prefix))
		declare @num_nextUserID int, @nextUserID nvarchar(10)
		set @lastUserID = LTRIM(RTRIM(@lastUserID))
		set @num_nextUserID = REPLACE(@lastUserID,@prefix,'') + 1
		set @size = @size -LEN(@prefix)
		set @nextUserID = @prefix + REPLICATE(0, @size - LEN(@prefix))
		set @nextUserID = @prefix + RIGHT(REPLICATE(0,@size) + CONVERT(nvarchar(max), @num_nextUserID), @size)
		return @nextUserID
	end
go


--Trigger loại
create trigger tr_NextLoaiID on LoaiSP
for insert
as
	begin
		declare @lastUserID nvarchar(10)
		SET @lastUserID = (select top 1 MaLoai from LoaiSP order by MaLoai desc)
		update LoaiSP set MaLoai = dbo.func_nextID(@lastUserID,'LSP',7) where MaLoai =''
	end
go

--Trigger Hãng
create trigger tr_NextHangID on HangSP
for insert
as
	begin
		declare @lastUserID nvarchar(10)
		SET @lastUserID = (select top 1 MaHang from HangSP order by MaHang desc)
		update HangSP set MaHang = dbo.func_nextID(@lastUserID,'HSP',7) where MaHang =''
	end
go

--Trigger Sản phẩm
create trigger tr_NextSP on SanPham
for insert
as
	begin
		declare @lastUserID nvarchar(10)
		SET @lastUserID = (select top 1 MaSP from SanPham order by MaSP desc)
		update SanPham set MaSP = dbo.func_nextID(@lastUserID,'SP',6) where MaSP =''
	end
go

--Trigger Nhân viên
create trigger tr_NextNV on NhanVien
for insert
as
	begin
		declare @lastUserID nvarchar(10)
		SET @lastUserID = (select top 1 MaNV from NhanVien order by MaNV desc)
		update NhanVien set MaNV = dbo.func_nextID(@lastUserID,'NV',6) where MaNV =''
	end
go

--Trigger Khách hàng
create trigger tr_NextKH on KhachHang
for insert
as
	begin
		declare @lastUserID nvarchar(10)
		SET @lastUserID = (select top 1 MaKH from KhachHang order by MaKH desc)
		update KhachHang set MaKH = dbo.func_nextID(@lastUserID,'KH',6) where MaKH =''
	end
go

--Trigger Khách hàng
create trigger tr_NextHDB on HoaDonBan
for insert
as
	begin
		declare @lastUserID nvarchar(10)
		SET @lastUserID = (select top 1 MaHDB from HoaDonBan order by MaHDB desc)
		update HoaDonBan set MaHDB = dbo.func_nextID(@lastUserID,'HDB',6) where MaHDB =''
	end
go

--Trigger Tin tức
create trigger tr_NextTT on TinTuc
for insert
as
	begin
		declare @lastUserID nvarchar(10)
		SET @lastUserID = (select top 1 MaTT from TinTuc order by MaTT desc)
		update TinTuc set MaTT = dbo.func_nextID(@lastUserID,'TT',6) where MaTT =''
	end
go




USE DatabaseBanHang_17SE111;
GO 
IF OBJECT_ID('TaiKhoan') IS NOT NULL
    BEGIN
        DROP TABLE TaiKhoan;
    END;
GO
CREATE TABLE TaiKhoan
    (
      MaTaiKhoan INT IDENTITY(1, 1)
                     PRIMARY KEY ,
      TenTaiKhoan NVARCHAR(30) ,
      IsDeLete BIT NOT NULL
                   DEFAULT ( 0 )
    );
INSERT  INTO dbo.TaiKhoan
        ( TenTaiKhoan, IsDeLete )
VALUES  ( N'Admin', -- TenTaiKhoan - nvarchar(30)
          0  -- IsDeLete - bit
          );
INSERT  INTO dbo.TaiKhoan
        ( TenTaiKhoan, IsDeLete )
VALUES  ( N'Quản Lý', -- TenTaiKhoan - nvarchar(30)
          0  -- IsDeLete - bit
          );
INSERT  INTO dbo.TaiKhoan
        ( TenTaiKhoan, IsDeLete )
VALUES  ( N'Nhân viên', -- TenTaiKhoan - nvarchar(30)
          0  -- IsDeLete - bit
          );
          
GO
--Bảng Nhân Viên
IF OBJECT_ID('NhanVien') IS NOT NULL
    BEGIN
        DROP TABLE NhanVien;
    END;
GO
CREATE TABLE NhanVien(
	MaNhanVien INT IDENTITY(1,1) PRIMARY KEY,
	TenNhanVien NVARCHAR(50) NOT NULL,
	NgaySinh DATE,
	DienThoai VARCHAR(13),
	MaTaiKhoan INT NOT NULL,
	TenDangNhap VARCHAR(30) NOT NULL,
	MatKhau VARBINARY(Max)NOT NULL,
	CONSTRAINT pk_NhanVien_TaiKhoan FOREIGN KEY(MaTaiKhoan) REFERENCES dbo.TaiKhoan(MaTaiKhoan)
)
GO
INSERT INTO dbo.NhanVien
        ( TenNhanVien ,
          NgaySinh ,
          DienThoai ,
          MaTaiKhoan ,
          TenDangNhap ,
          MatKhau
        )
VALUES  ( N'Admin' , -- TenNhanVien - nvarchar(50)
         '2000-02-02' , -- NgaySinh - date
          '098123123' , -- DienThoai - varchar(13)
          1 , -- MaTaiKhoan - int
          'admin' , -- TenDangNhap - varchar(30)
          pwdencrypt('admin')  -- MatKhau - varbinary(max)
        )
        INSERT INTO dbo.NhanVien
        ( TenNhanVien ,
          NgaySinh ,
          DienThoai ,
          MaTaiKhoan ,
          TenDangNhap ,
          MatKhau
        )
VALUES  ( N'Nguyễn Van A' , -- TenNhanVien - nvarchar(50)
         '2002-02-02' , -- NgaySinh - date
          '0983453635' , -- DienThoai - varchar(13)
          2 , -- MaTaiKhoan - int
          'quanly' , -- TenDangNhap - varchar(30)
          pwdencrypt('quanly')  -- MatKhau - varbinary(max)
        )
        INSERT INTO dbo.NhanVien
        ( TenNhanVien ,
          NgaySinh ,
          DienThoai ,
          MaTaiKhoan ,
          TenDangNhap ,
          MatKhau
        )
VALUES  ( N'Nguyễn Hoàng Anh Thư' , -- TenNhanVien - nvarchar(50)
         '2000-02-02' , -- NgaySinh - date
          '098123123' , -- DienThoai - varchar(13)
          3 , -- MaTaiKhoan - int
          'nhanvien' , -- TenDangNhap - varchar(30)
          pwdencrypt('nhanvien')  -- MatKhau - varbinary(max)
        )
GO
IF OBJECT_ID('ChucNang') IS NOT NULL
    BEGIN
        DROP TABLE ChucNang;
    END;
GO   
CREATE TABLE ChucNang(
	MaChucNang INT IDENTITY(1,1) PRIMARY KEY,
	TenChucNang NVARCHAR(100) NOT NULL,
	KyHieuChucNang VARCHAR(100) NOT NULL,--Frm_Main
	MoTa NVARCHAR(200),
	NhomChucNang INT NOT NULL,
	ChucNangCha INT ,
	IsDelete BIT NOT NULL DEFAULT(0)
)   
GO
IF OBJECT_ID('PhanQuyen') IS NOT NULL
    BEGIN
        DROP TABLE PhanQuyen;
    END;
GO  
CREATE TABLE PhanQuyen(
	MaChucNang INT ,
	MaTaiKhoan INT ,
	TongQuyen INT NOT NULL DEFAULT(0),
	IsDelete BIT NOT NULL DEFAULT(0),
	CONSTRAINT pk_PhanQuyen PRIMARY KEY(MaChucNang,MaTaiKhoan),
	CONSTRAINT fk_ChucNang_PhanQuyen FOREIGN KEY(MaChucNang) REFERENCES dbo.ChucNang(MaChucNang),
	CONSTRAINT fk_TaiKhoan_PhanQuyen FOREIGN KEY(MaTaiKhoan) REFERENCES dbo.TaiKhoan(MaTaiKhoan)	
)    
GO
ALTER TABLE dbo.NhanVien
ADD IsDelete BIT NOT NULL DEFAULT(0)
GO
--Thủ tục kiểm tra đăng nhập
CREATE PROC PSP_NhanVien_KiemTraDangNhap --'admin','admin'
@TenDangNhap VARCHAR(30),
@MatKhau VARCHAR(30)
AS	
IF EXISTS (SELECT 1 FROM dbo.NhanVien WHERE TenDangNhap=@TenDangNhap AND pwdcompare(@MatKhau,MatKhau)=1)
BEGIN
    SELECT 1 AS code,TenNhanVien,MaTaiKhoan FROM dbo.NhanVien WHERE TenDangNhap=@TenDangNhap AND pwdcompare(@MatKhau,MatKhau)=1
END
ELSE
BEGIN
    SELECT 0 AS code,'' AS TenNhanVien,0 AS MaTaiKhoan
END

GO
IF OBJECT_ID('dbo.PSP_NhanVien_LayDanhSachNhanVien')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhanVien_LayDanhSachNhanVien;
END
GO
CREATE PROC PSP_NhanVien_LayDanhSachNhanVien
AS
SELECT ROW_NUMBER() over (order by (select 1)) as STT, MaNhanVien, TenNhanVien, NgaySinh, DienThoai, MaTaiKhoan, TenDangNhap, MatKhau
FROM dbo.NhanVien
WHERE IsDelete=0
GO
IF OBJECT_ID('dbo.PSP_NhanVien_InsertVaUpdate')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhanVien_InsertVaUpdate;
END
GO
CREATE PROC PSP_NhanVien_InsertVaUpdate
@MaNhanVien int, 
@TenNhanVien NVARCHAR(50), 
@NgaySinh date, 
@DienThoai VARCHAR(13), 
@MaTaiKhoan INT , 
@TenDangNhap VARCHAR(30), 
@MatKhau VARCHAR(30)
AS
IF EXISTS (SELECT 1 FROM dbo.NhanVien WHERE MaNhanVien=@MaNhanVien)
BEGIN
    UPDATE dbo.NhanVien
    SET TenNhanVien=@TenNhanVien,
		NgaySinh=@NgaySinh,
		DienThoai=@DienThoai,
		MaTaiKhoan=@MaTaiKhoan,
		TenDangNhap=@TenDangNhap
	WHERE MaNhanVien=@MaNhanVien
END
ELSE	
BEGIN
    INSERT INTO dbo.NhanVien
            ( TenNhanVien ,
              NgaySinh ,
              DienThoai ,
              MaTaiKhoan ,
              TenDangNhap ,
              MatKhau
            )
    VALUES  ( @TenNhanVien , -- TenNhanVien - nvarchar(50)
             @NgaySinh , -- NgaySinh - date
              @DienThoai , -- DienThoai - varchar(13)
              @MaTaiKhoan , -- MaTaiKhoan - int
              @TenDangNhap , -- TenDangNhap - varchar(30)
              pwdencrypt(@MatKhau) -- MatKhau - varbinary(max)
            )
END
go
IF OBJECT_ID('dbo.PSP_TaiKhoan_LayCombo')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_TaiKhoan_LayCombo;
END
GO
CREATE PROC PSP_TaiKhoan_LayCombo
AS
SELECT MaTaiKhoan, TenTaiKhoan FROM dbo.TaiKhoan WHERE  IsDeLete=0
--/////////////////////-----//////////////////
IF OBJECT_ID('LoaiSanPham')IS NOT NULL
BEGIN
    DROP TABLE LoaiSanPham;
END
GO
CREATE TABLE LoaiSanPham
(
	MaLoaiSanPham INT IDENTITY(1,1) PRIMARY KEY,
	TenLoaiSanPham NVARCHAR(30) NOT NULL,
	MoTa NVARCHAR(200),
	IsDelete BIT NOT NULL DEFAULT(0)
)
GO 
IF OBJECT_ID('DonViTinh')IS NOT NULL
BEGIN
    DROP TABLE DonViTinh;
END
GO
CREATE TABLE DonViTinh
(
	MaDonViTinh INT IDENTITY(1,1) PRIMARY KEY,
	TenDonViTinh NVARCHAR(30) NOT NULL,
	MoTa NVARCHAR(200),
	IsDelete BIT NOT NULL DEFAULT(0)
)
GO 
IF OBJECT_ID('NhaCungCap')IS NOT NULL
BEGIN
    DROP TABLE NhaCungCap;
END
GO
CREATE TABLE NhaCungCap
(
	MaNhaCungCap INT IDENTITY(1,1) PRIMARY KEY,
	TenNhaCungCap NVARCHAR(30) NOT NULL,
	MoTa NVARCHAR(200),
	IsDelete BIT NOT NULL DEFAULT(0)
)
GO
INSERT INTO dbo.LoaiSanPham
        ( TenLoaiSanPham, MoTa, IsDelete )
VALUES  ( N'Nước giải khát', -- TenLoaiSanPham - nvarchar(30)
          N'', -- MoTa - nvarchar(200)
          0  -- IsDelete - bit
          )
          INSERT INTO dbo.LoaiSanPham
        ( TenLoaiSanPham, MoTa, IsDelete )
VALUES  ( N'Bánh kẹo', -- TenLoaiSanPham - nvarchar(30)
          N'', -- MoTa - nvarchar(200)
          0  -- IsDelete - bit
          )
          INSERT INTO dbo.LoaiSanPham
        ( TenLoaiSanPham, MoTa, IsDelete )
VALUES  ( N'Gia vị', -- TenLoaiSanPham - nvarchar(30)
          N'', -- MoTa - nvarchar(200)
          0  -- IsDelete - bit
          )
          GO
 INSERT INTO dbo.DonViTinh
         ( TenDonViTinh, MoTa, IsDelete )
 VALUES  ( N'Thùng', -- TenDonViTinh - nvarchar(30)
           N'', -- MoTa - nvarchar(200)
           0  -- IsDelete - bit
           )
            INSERT INTO dbo.DonViTinh
         ( TenDonViTinh, MoTa, IsDelete )
 VALUES  ( N'Lon', -- TenDonViTinh - nvarchar(30)
           N'', -- MoTa - nvarchar(200)
           0  -- IsDelete - bit
           )
            INSERT INTO dbo.DonViTinh
         ( TenDonViTinh, MoTa, IsDelete )
 VALUES  ( N'Cái', -- TenDonViTinh - nvarchar(30)
           N'', -- MoTa - nvarchar(200)
           0  -- IsDelete - bit
           )
           GO
           INSERT INTO dbo.NhaCungCap
                   ( TenNhaCungCap, MoTa, IsDelete )
           VALUES  ( N'Cocacola', -- TenNhaCungCap - nvarchar(30)
                     N'', -- MoTa - nvarchar(200)
                     0  -- IsDelete - bit
                     )
                     INSERT INTO dbo.NhaCungCap
                   ( TenNhaCungCap, MoTa, IsDelete )
           VALUES  ( N'Cty Gấu đỏ', -- TenNhaCungCap - nvarchar(30)
                     N'', -- MoTa - nvarchar(200)
                     0  -- IsDelete - bit
                     )
                     INSERT INTO dbo.NhaCungCap
                   ( TenNhaCungCap, MoTa, IsDelete )
           VALUES  ( N'Cty TNHH Beer Sài gòn', -- TenNhaCungCap - nvarchar(30)
                     N'', -- MoTa - nvarchar(200)
                     0  -- IsDelete - bit
                     )
                     
 GO
 GO 
IF OBJECT_ID('SanPham')IS NOT NULL
BEGIN
    DROP TABLE SanPham;
END
GO
CREATE TABLE SanPham(
	MaSanPham INT IDENTITY(1,1) PRIMARY KEY,
	TenSanPham NVARCHAR(50) NOT NULL,
	MoTa NVARCHAR(200),
	MaDonViTinh INT,
	MaLoaiSanPham INT,
	MaNhaCungCap INT,
	SoLuongTon BIGINT,
	DonGiaBinhQuan BIGINT,
	IsDelete BIT NOT NULL DEFAULT(0),
	CONSTRAINT fk_DonViTinh FOREIGN KEY(MaDonViTinh)REFERENCES dbo.DonViTinh(MaDonViTinh),
CONSTRAINT fk_NhaCungCap FOREIGN KEY(MaNhaCungCap)REFERENCES dbo.NhaCungCap(MaNhaCungCap),
CONSTRAINT fk_LoaiSanPham FOREIGN KEY(MaLoaiSanPham)REFERENCES dbo.LoaiSanPham(MaLoaiSanPham)		
)
GO
IF OBJECT_ID('PhieuNhap')IS NOT NULL
BEGIN
    DROP TABLE PhieuNhap;
END
GO
CREATE	TABLE PhieuNhap(
	MaPhieuNhap CHAR(13) PRIMARY KEY,--PN20030100001
	NgayNhap DATETIME NOT NULL DEFAULT(GETDATE()),
	MaNhanVien INT NOT NULL,
	CONSTRAINT fk_NhanVien FOREIGN KEY(MaNhanVien)REFERENCES dbo.NhanVien(MaNhanVien)
)
GO
IF OBJECT_ID('ChiTietPhieuNhap')IS NOT NULL
BEGIN
    DROP TABLE ChiTietPhieuNhap;
END
GO
CREATE TABLE ChiTietPhieuNhap
(
	MaPhieuNhap CHAR(13) NOT NULL,
	MaSanPham INT NOT NULL,
	SoLuongNhap BIGINT,
	DonGiaNhap BIGINT,
	SoLuongNhapTon BIGINT,
	CONSTRAINT pk_ChiTietPhieuNhap PRIMARY KEY(MaPhieuNhap,MaSanPham),
CONSTRAINT fk_PhieuNhap FOREIGN KEY(MaPhieuNhap) REFERENCES dbo.PhieuNhap (MaPhieuNhap),
	CONSTRAINT fk_SanPham FOREIGN KEY(MaSanPham) REFERENCES dbo.SanPham (MaSanPham)
)
GO
IF OBJECT_ID('HoaDon')IS NOT NULL
BEGIN
    DROP TABLE HoaDon;
END
GO
CREATE TABLE HoaDon
( 
	MaHoaDon CHAR(13) NOT NULL PRIMARY KEY,
	NgayLap DATETIME NOT NULL DEFAULT(GETDATE()),
	MaNhanVien INT NOT NULL,
	GiamGia BIGINT NOT NULL DEFAULT(0),
	CONSTRAINT fk_NhanVien_HoaDon FOREIGN KEY(MaNhanVien) REFERENCES dbo.NhanVien(MaNhanVien)
)
GO
IF OBJECT_ID('ChiTietHoaDon')IS NOT NULL
BEGIN
    DROP TABLE ChiTietHoaDon;
END
GO
CREATE TABLE ChiTietHoaDon(
	MaHoaDon CHAR(13) NOT NULL,
	MaSanPham INT NOT null,
	SoLuongBan BIGINT NOT NULL DEFAULT(0),
	DonGiaBan BIGINT NOT NULL DEFAULT(0),
	GiamGia BIGINT NOT NULL DEFAULT(0),
	CONSTRAINT pk_ChiTietHoaDon PRIMARY KEY(MaHoaDon,MaSanPham),
	CONSTRAINT fk_HoaDonChiTietHoaDOn FOREIGN KEY(MaHoaDon) REFERENCES dbo.HoaDon(MaHoaDon),
CONSTRAINT fk_SanPhamChiTietHoaDOn FOREIGN KEY(MaSanPham) REFERENCES dbo.SanPham(MaSanPham)	
)
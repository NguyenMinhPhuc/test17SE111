--Chuẩn bị dữ liệu trong các bảng
--DonViTinh
INSERT INTO DonViTinh(TenDonViTinh, MoTa, IsDelete)
VALUES(N'Thùng',N'',0),
(N'Cái',N'',0),
(N'Gói',N'',0),
(N'Lon',N'',0)
GO
INSERT INTO LoaiSanPham( TenLoaiSanPham, MoTa, IsDelete)
VALUES(N'Nước giải khát',N'',0),
(N'Gia vị',N'',0),
(N'Bánh kẹo',N'',0),
(N'Thực phẩm',N'',0)
GO
INSERT INTO NhaCungCap(TenNhaCungCap, MoTa, IsDelete)
VALUES(N'Cô ca cô la',N'',0),
(N'Bia Sài Gòn',N'',0),
(N'bánh kẹo bibica',N'',0),
(N'Bột ngọt Vedan',N'',0)
GO
INSERT INTO dbo.PhieuNhap
        ( MaPhieuNhap, NgayNhap, MaNhanVien )
VALUES  ( 'PN2003010001',GETDATE(), 1  )
GO
INSERT INTO SanPham( TenSanPham, MoTa, MaDonViTinh, MaLoaiSanPham,MaNhaCungCap , SoLuongTon, DonGiaBinhQuan, IsDelete)
VALUES(N'Cocacola',N'',1,1,4,10,20000,0),
(N'Kẹo bốn mùa',N'',2,3,5,10,20000,0),
(N'bột ngọt vedan',N'',3,3,6,10,15000,0)
GO

INSERT INTO dbo.ChiTietPhieuNhap
        ( MaPhieuNhap ,MaSanPham , SoLuongNhap , DonGiaNhap ,
          SoLuongNhapTon )
VALUES  ( 'PN2003010001' ,4 , 10 ,20000 ,  10  ),
( 'PN2003010001' ,5 , 10 ,20000 ,  10  ),
( 'PN2003010001' ,6 , 10 ,15000 ,  10  )
GO
IF OBJECT_ID('dbo.PSP_NhapHang_LayChiTietNhapHang')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhapHang_LayChiTietNhapHang;
END
GO
CREATE PROC dbo.PSP_NhapHang_LayChiTietNhapHang
AS
SELECT ROW_NUMBER() over (order by (select 1))  AS STT,a.MaPhieuNhap,a.NgayNhap,a.MaNhanVien,c.TenNhanVien,b.MaSanPham,d.TenSanPham, b.SoLuongNhap,b.SoLuongNhapTon,b.DonGiaNhap,b.SoLuongNhap*b.DonGiaNhap AS ThanhTienNhap,d.MaLoaiSanPham,e.TenLoaiSanPham,d.MaNhaCungCap,f.TenNhaCungCap,d.MaDonViTinh,g.TenDonViTinh
FROM dbo.PhieuNhap a JOIN dbo.ChiTietPhieuNhap b ON b.MaPhieuNhap = a.MaPhieuNhap JOIN dbo.NhanVien c ON c.MaNhanVien = a.MaNhanVien JOIN dbo.SanPham d ON d.MaSanPham = b.MaSanPham JOIN dbo.LoaiSanPham e ON e.MaLoaiSanPham = d.MaLoaiSanPham JOIN dbo.NhaCungCap f ON f.MaNhaCungCap = d.MaNhaCungCap join dbo.DonViTinh g ON g.MaDonViTinh = d.MaDonViTinh
GO
--PN2003010001 
IF OBJECT_ID('dbo.PSP_NhapHang_LayMaPhieuNhapLonNhat')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhapHang_LayMaPhieuNhapLonNhat;
END
GO
CREATE PROC PSP_NhapHang_LayMaPhieuNhapLonNhat-- 2
@MaNhanVien INT
AS
SELECT ISNULL( CONVERT(int,SUBSTRING(MAX(MaPhieuNhap),9,4)),0)AS IDMax
FROM dbo.PhieuNhap
WHERE SUBSTRING(CONVERT(CHAR(4),YEAR(GETDATE())),3,2)=SUBSTRING(MaPhieuNhap,3,2) AND
MONTH(GETDATE())=CONVERT(INT,SUBSTRING( MaPhieuNhap,5,2))AND
@MaNhanVien=CONVERT(INT,SUBSTRING(MaPhieuNhap,7,2))
GO
IF OBJECT_ID('dbo.PSP_NhapHang_LayMaPhieuNhapLonNhatTheoNgay')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhapHang_LayMaPhieuNhapLonNhatTheoNgay;
END
GO
CREATE PROC PSP_NhapHang_LayMaPhieuNhapLonNhatTheoNgay-- 2
@MaNhanVien INT,
@NgayNhap date
AS
SELECT ISNULL( CONVERT(int,SUBSTRING(MAX(MaPhieuNhap),9,4)),0)AS IDMax
FROM dbo.PhieuNhap
WHERE SUBSTRING(CONVERT(CHAR(4),YEAR(@NgayNhap)),3,2)=SUBSTRING(MaPhieuNhap,3,2) AND
MONTH(@NgayNhap)=CONVERT(INT,SUBSTRING( MaPhieuNhap,5,2))AND
@MaNhanVien=CONVERT(INT,SUBSTRING(MaPhieuNhap,7,2))
GO
IF OBJECT_ID('dbo.PSP_NhapHang_LayLoaiSanPhamCbo')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhapHang_LayLoaiSanPhamCbo;
END
GO
CREATE PROC PSP_NhapHang_LayLoaiSanPhamCbo
AS
SELECT MaLoaiSanPham,TenLoaiSanPham
FROM dbo.LoaiSanPham
WHERE IsDelete=0
GO
IF OBJECT_ID('dbo.PSP_NhapHang_LayDonViTinhCbo')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhapHang_LayDonViTinhCbo;
END
GO
CREATE PROC PSP_NhapHang_LayDonViTinhCbo
AS
SELECT MaDonViTinh,TenDonViTinh
FROM dbo.DonViTinh
WHERE IsDelete=0
GO
GO
IF OBJECT_ID('dbo.PSP_NhapHang_LayNhaCungCapCbo')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhapHang_LayNhaCungCapCbo;
END
GO
CREATE PROC PSP_NhapHang_LayNhaCungCapCbo
AS
SELECT MaNhaCungCap,TenNhaCungCap
FROM dbo.NhaCungCap
WHERE IsDelete=0
GO
IF OBJECT_ID('dbo.PSP_NhapHang_LayThongTinSanPhamTheoLoai')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhapHang_LayThongTinSanPhamTheoLoai;
END
GO

CREATE PROC PSP_NhapHang_LayThongTinSanPhamTheoLoai 3
@MaLoaiSanPham INT
AS
SELECT MaSanPham, TenSanPham, MoTa, MaDonViTinh, MaLoaiSanPham, MaNhaCungCap, SoLuongTon, DonGiaBinhQuan
FROM dbo.SanPham 
WHERE MaLoaiSanPham=@MaLoaiSanPham AND IsDelete=0
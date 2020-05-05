USE DatabaseBanHang_17SE111
GO
--Phần Thủ tục xử lý cho ngày 09-04-2020
--Thủ tục để thêm 1 chi tiết phiếu nhập.
IF OBJECT_ID('dbo.PSP_NhapHang_InsertChiTietPhieuNhap')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhapHang_InsertChiTietPhieuNhap;
END
GO
CREATE PROC dbo.PSP_NhapHang_InsertChiTietPhieuNhap
@MaPhieuNhap CHAR(13), 
@NgayNhap DATETIME, 
@MaNhanVien INT,
@MaSanPham int, 
@SoLuongNhap BIGINT, 
@DonGiaNhap BIGINT,
@TenSanPham nvarchar(50), 
@MoTa NVARCHAR(200), 
@MaDonViTinh INT, 
@MaLoaiSanPham INT, 
@MaNhaCungCap INT 
AS
SET XACT_ABORT ON
BEGIN TRAN
--Kiểm tra phiếu nhập tồn tài
	--nếu có
		--kiem tra xem san pham co chua
	--ngược cách khác
		--kiem tra xem san pham co chua
DECLARE @MaSanPhamNew INT;
IF EXISTS (SELECT 1 FROM dbo.PhieuNhap WHERE MaPhieuNhap=@MaPhieuNhap)
	BEGIN--có mã phiếu nhập
		IF EXISTS (SELECT 1 FROM dbo.SanPham WHERE MaSanPham=@MaSanPham)
			BEGIN--có sản phẩm
			    INSERT INTO ChiTietPhieuNhap(MaPhieuNhap, MaSanPham, SoLuongNhap, DonGiaNhap, SoLuongNhapTon)
			    VALUES(@MaPhieuNhap, @MaSanPham, @SoLuongNhap, @DonGiaNhap, @SoLuongNhap)
			END	--Có sản phẩm
		ELSE	
			BEGIN --Không có sản phẩm
				INSERT INTO SanPham(TenSanPham, MoTa, MaDonViTinh, MaLoaiSanPham, MaNhaCungCap, SoLuongTon, DonGiaBinhQuan, IsDelete)
				VALUES(@TenSanPham, @MoTa, @MaDonViTinh, @MaLoaiSanPham, @MaNhaCungCap, 0, 0, 0)
				
				SET @MaSanPhamNew=(SELECT MAX(MaSanPham)FROM dbo.SanPham WHERE IsDelete=0)
				
				INSERT INTO ChiTietPhieuNhap(MaPhieuNhap, MaSanPham, SoLuongNhap, DonGiaNhap, SoLuongNhapTon)
			    VALUES(@MaPhieuNhap, @MaSanPhamNew, @SoLuongNhap, @DonGiaNhap, @SoLuongNhap)			
			END --không có sản phẩm
	END--có mã phiếu nhập
ELSE	
	BEGIN--không có mã phiếu nhập
		INSERT INTO	dbo.PhieuNhap( MaPhieuNhap, NgayNhap, MaNhanVien )
		VALUES  (@MaPhieuNhap, @NgayNhap, @MaNhanVien)
	    
	    IF EXISTS (SELECT 1 FROM dbo.SanPham WHERE MaSanPham=@MaSanPham)
			BEGIN--có sản phẩm
			    INSERT INTO ChiTietPhieuNhap(MaPhieuNhap, MaSanPham, SoLuongNhap, DonGiaNhap, SoLuongNhapTon)
			    VALUES(@MaPhieuNhap, @MaSanPham, @SoLuongNhap, @DonGiaNhap, @SoLuongNhap)
			END	--Có sản phẩm
		ELSE	
			BEGIN --Không có sản phẩm
				INSERT INTO SanPham(TenSanPham, MoTa, MaDonViTinh, MaLoaiSanPham, MaNhaCungCap, SoLuongTon, DonGiaBinhQuan, IsDelete)
				VALUES(@TenSanPham, @MoTa, @MaDonViTinh, @MaLoaiSanPham, @MaNhaCungCap, 0, 0, 0)
				
			
				SET @MaSanPhamNew=(SELECT MAX(MaSanPham)FROM dbo.SanPham WHERE IsDelete=0)
				
				INSERT INTO ChiTietPhieuNhap(MaPhieuNhap, MaSanPham, SoLuongNhap, DonGiaNhap, SoLuongNhapTon)
			    VALUES(@MaPhieuNhap, @MaSanPhamNew, @SoLuongNhap, @DonGiaNhap, @SoLuongNhap)			
			END --không có sản phẩm
	END	--không có mã phiếu nhập
	COMMIT
GO
ALTER PROC [dbo].[PSP_NhapHang_LayChiTietNhapHang]--'PN2003010002'
@MaPhieuNhap CHAR(13) ='0'
AS
    SELECT  ROW_NUMBER() OVER ( ORDER BY ( SELECT   1
                                         ) ) AS STT ,
            a.MaPhieuNhap ,
            a.NgayNhap ,
            a.MaNhanVien ,
            c.TenNhanVien ,
            b.MaSanPham ,
            d.TenSanPham ,
            b.SoLuongNhap ,
            b.SoLuongNhapTon ,
            b.DonGiaNhap ,
            b.SoLuongNhap * b.DonGiaNhap AS ThanhTienNhap ,
            d.MaLoaiSanPham ,
            e.TenLoaiSanPham ,
            d.MaNhaCungCap ,
            f.TenNhaCungCap ,
            d.MaDonViTinh ,
            g.TenDonViTinh
    FROM    dbo.PhieuNhap a
            JOIN dbo.ChiTietPhieuNhap b ON b.MaPhieuNhap = a.MaPhieuNhap
            JOIN dbo.NhanVien c ON c.MaNhanVien = a.MaNhanVien
            JOIN dbo.SanPham d ON d.MaSanPham = b.MaSanPham
            JOIN dbo.LoaiSanPham e ON e.MaLoaiSanPham = d.MaLoaiSanPham
            JOIN dbo.NhaCungCap f ON f.MaNhaCungCap = d.MaNhaCungCap
            JOIN dbo.DonViTinh g ON g.MaDonViTinh = d.MaDonViTinh
           WHERE @MaPhieuNhap = CASE @MaPhieuNhap WHEN '0' THEN '0'ELSE a.MaPhieuNhap END
           
GO
IF OBJECT_ID('dbo.PSP_NhapHang_UpdateChiTietPhieuNhap') IS NOT NULL
    BEGIN
        DROP PROC dbo.PSP_NhapHang_UpdateChiTietPhieuNhap;
    END;
GO
CREATE PROC dbo.PSP_NhapHang_UpdateChiTietPhieuNhap
    @MaPhieuNhap CHAR(13), 
@NgayNhap DATETIME, 
@MaNhanVien INT,
@MaSanPham int, 
@SoLuongNhap BIGINT, 
@DonGiaNhap BIGINT,
@TenSanPham nvarchar(50), 
@MoTa NVARCHAR(200), 
@MaDonViTinh INT, 
@MaLoaiSanPham INT, 
@MaNhaCungCap INT 
AS
SET XACT_ABORT ON
BEGIN TRAN
    UPDATE  dbo.SanPham
    SET     TenSanPham = @TenSanPham ,
            MoTa = @MoTa ,
            MaDonViTinh = @MaDonViTinh ,
            MaLoaiSanPham = @MaLoaiSanPham ,
            MaNhaCungCap = @MaNhaCungCap
    WHERE   MaSanPham = @MaSanPham;      

    UPDATE  dbo.PhieuNhap
    SET     NgayNhap = @NgayNhap
    WHERE   MaPhieuNhap = @MaPhieuNhap;

    UPDATE  dbo.ChiTietPhieuNhap
    SET     SoLuongNhap = @SoLuongNhap ,
            DonGiaNhap = @DonGiaNhap,
            SoLuongNhapTon=@SoLuongNhap
    WHERE   MaPhieuNhap = @MaPhieuNhap
            AND MaSanPham = @MaSanPham;    
COMMIT
GO
IF OBJECT_ID('dbo.PSP_NhapHang_XoaChiTietPhieuNhap') IS NOT NULL
    BEGIN
        DROP PROC dbo.PSP_NhapHang_XoaChiTietPhieuNhap;
    END;
GO
CREATE PROC PSP_NhapHang_XoaChiTietPhieuNhap
@MaPhieuNhap CHAR(13),
@MaSanPham INT
AS 
SET XACT_ABORT ON
BEGIN TRAN
	DELETE dbo.ChiTietPhieuNhap
	WHERE MaPhieuNhap=@MaPhieuNhap AND MaSanPham =@MaSanPham
	
	IF NOT EXISTS (SELECT 1 FROM dbo.ChiTietPhieuNhap WHERE MaPhieuNhap=@MaPhieuNhap)
	BEGIN
		DELETE dbo.PhieuNhap
		WHERE MaPhieuNhap=@MaPhieuNhap
	END	
COMMIT
go
--Trigger để kiểm soát tồn.
--INSERT
CREATE TRIGGER [dbo].[InsertChiTietPhieuNhap]
   ON   [dbo].[ChiTietPhieuNhap]
   AFTER INSERT
AS 
BEGIN
	DECLARE @DonGiaNhapBinhQuan bigint
	SET @DonGiaNhapBinhQuan=(SELECT AVG(DonGiaNhap) FROM ChiTietPhieuNhap WHERE MaSanPham =(SELECT MaSanPham FROM Inserted))
	
	UPDATE SanPham
	SET SoLuongTon+=(SELECT SoLuongNhap FROM Inserted),
	DonGiaBinhQuan=@DonGiaNhapBinhQuan
	WHERE MaSanPham=(SELECT MaSanPham FROM Inserted)
END
GO
CREATE TRIGGER [dbo].[UpdateChiTietPhieuNhap]
   ON   [dbo].[ChiTietPhieuNhap]
   AFTER UPDATE
AS 
BEGIN
DECLARE @DonGiaNhapBinhQuan FLOAT
	SET @DonGiaNhapBinhQuan=(SELECT AVG(DonGiaNhap) FROM ChiTietPhieuNhap WHERE MaSanPham =(SELECT MaSanPham FROM Inserted))

	DECLARE @SoLuongMoi FLOAT
	SET @SoLuongMoi=(SELECT SoLuongNhap FROM Inserted)
	
	DECLARE @SoLuongCu FLOAT
	SET @SoLuongCu=(SELECT SoLuongNhap FROM Deleted)
	
	UPDATE SanPham
	SET SoLuongTon+=@SoLuongMoi-@SoLuongCu,
	DonGiaBinhQuan=@DonGiaNhapBinhQuan
	WHERE MaSanPham=(SELECT MaSanPham FROM Inserted)
END
GO
CREATE TRIGGER [dbo].[DeleteChiTietPhieuNhap]
   ON   [dbo].[ChiTietPhieuNhap]
   AFTER DELETE
AS 
BEGIN
DECLARE @DonGiaNhapBinhQuan FLOAT
	SET @DonGiaNhapBinhQuan=(SELECT ISNULL(AVG(DonGiaNhap),0) FROM ChiTietPhieuNhap WHERE MaSanPham =(SELECT MaSanPham FROM Deleted))
	UPDATE SanPham
	SET SoLuongTon-=(SELECT SoLuongNhap FROM Deleted),
	DonGiaBinhQuan=@DonGiaNhapBinhQuan
	WHERE MaSanPham=(SELECT MaSanPham FROM Deleted)
END
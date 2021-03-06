USE [DatabaseBanHang_17SE111];
GO
/****** Object:  StoredProcedure [dbo].[PSP_NhapHang_InsertChiTietPhieuNhap]    Script Date: 04/23/2020 09:57:18 ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER PROC [dbo].[PSP_NhapHang_InsertChiTietPhieuNhap]
    @MaPhieuNhap CHAR(13) ,
    @NgayNhap DATETIME ,
    @MaNhanVien INT ,
    @MaSanPham INT ,
    @SoLuongNhap BIGINT ,
    @DonGiaNhap BIGINT ,
    @TenSanPham NVARCHAR(50) ,
    @MoTa NVARCHAR(200) ,
    @MaDonViTinh INT ,
    @MaLoaiSanPham INT ,
    @MaNhaCungCap INT ,
    @DonGiaBan INT
AS --Kiểm tra phiếu nhập tồn tài
	--nếu có
		--kiem tra xem san pham co chua
	--ngược cách khác
		--kiem tra xem san pham co chua
    DECLARE @MaSanPhamNew INT;
    IF EXISTS ( SELECT  1
                FROM    dbo.PhieuNhap
                WHERE   MaPhieuNhap = @MaPhieuNhap )
        BEGIN--có mã phiếu nhập
            IF EXISTS ( SELECT  1
                        FROM    dbo.SanPham
                        WHERE   MaSanPham = @MaSanPham )
                BEGIN--có sản phẩm
                    INSERT  INTO ChiTietPhieuNhap
                            ( MaPhieuNhap ,
                              MaSanPham ,
                              SoLuongNhap ,
                              DonGiaNhap ,
                              SoLuongNhapTon
                            )
                    VALUES  ( @MaPhieuNhap ,
                              @MaSanPham ,
                              @SoLuongNhap ,
                              @DonGiaNhap ,
                              @SoLuongNhap
                            );
                END;	--Có sản phẩm
            ELSE
                BEGIN --Không có sản phẩm
                    INSERT  INTO SanPham
                            ( TenSanPham ,
                              MoTa ,
                              MaDonViTinh ,
                              MaLoaiSanPham ,
                              MaNhaCungCap ,
                              SoLuongTon ,
                              DonGiaBinhQuan ,
                              IsDelete
                            )
                    VALUES  ( @TenSanPham ,
                              @MoTa ,
                              @MaDonViTinh ,
                              @MaLoaiSanPham ,
                              @MaNhaCungCap ,
                              0 ,
                              0 ,
                              0
                            );
				
                    SET @MaSanPhamNew = ( SELECT    MAX(MaSanPham)
                                          FROM      dbo.SanPham
                                          WHERE     IsDelete = 0
                                        );
				
                    INSERT  INTO ChiTietPhieuNhap
                            ( MaPhieuNhap ,
                              MaSanPham ,
                              SoLuongNhap ,
                              DonGiaNhap ,
                              SoLuongNhapTon
                            )
                    VALUES  ( @MaPhieuNhap ,
                              @MaSanPhamNew ,
                              @SoLuongNhap ,
                              @DonGiaNhap ,
                              @SoLuongNhap
                            );	
		
                    INSERT  INTO GiaBan
                            ( MaSanPham, GiaBanHienHanh )
                    VALUES  ( @MaSanPhamNew, @DonGiaBan );	    		
                END; --không có sản phẩm
        END;--có mã phiếu nhập
    ELSE
        BEGIN--không có mã phiếu nhập
            INSERT  INTO dbo.PhieuNhap
                    ( MaPhieuNhap ,
                      NgayNhap ,
                      MaNhanVien
                    )
            VALUES  ( @MaPhieuNhap ,
                      @NgayNhap ,
                      @MaNhanVien
                    );
	    
            IF EXISTS ( SELECT  1
                        FROM    dbo.SanPham
                        WHERE   MaSanPham = @MaSanPham )
                BEGIN--có sản phẩm
                    INSERT  INTO ChiTietPhieuNhap
                            ( MaPhieuNhap ,
                              MaSanPham ,
                              SoLuongNhap ,
                              DonGiaNhap ,
                              SoLuongNhapTon
                            )
                    VALUES  ( @MaPhieuNhap ,
                              @MaSanPham ,
                              @SoLuongNhap ,
                              @DonGiaNhap ,
                              @SoLuongNhap
                            );
                END;	--Có sản phẩm
            ELSE
                BEGIN --Không có sản phẩm
                    INSERT  INTO SanPham
                            ( TenSanPham ,
                              MoTa ,
                              MaDonViTinh ,
                              MaLoaiSanPham ,
                              MaNhaCungCap ,
                              SoLuongTon ,
                              DonGiaBinhQuan ,
                              IsDelete
                            )
                    VALUES  ( @TenSanPham ,
                              @MoTa ,
                              @MaDonViTinh ,
                              @MaLoaiSanPham ,
                              @MaNhaCungCap ,
                              0 ,
                              0 ,
                              0
                            );
				
			
                    SET @MaSanPhamNew = ( SELECT    MAX(MaSanPham)
                                          FROM      dbo.SanPham
                                          WHERE     IsDelete = 0
                                        );
				
                    INSERT  INTO ChiTietPhieuNhap
                            ( MaPhieuNhap ,
                              MaSanPham ,
                              SoLuongNhap ,
                              DonGiaNhap ,
                              SoLuongNhapTon
                            )
                    VALUES  ( @MaPhieuNhap ,
                              @MaSanPhamNew ,
                              @SoLuongNhap ,
                              @DonGiaNhap ,
                              @SoLuongNhap
                            );	
		
                    INSERT  INTO GiaBan
                            ( MaSanPham, GiaBanHienHanh )
                    VALUES  ( @MaSanPhamNew, @DonGiaBan );			
                END; --không có sản phẩm
        END;	--không có mã phiếu nhập
GO
USE [DatabaseBanHang_17SE111];
GO
/****** Object:  StoredProcedure [dbo].[PSP_NhapHang_LayChiTietNhapHang]    Script Date: 04/23/2020 10:02:51 ******/
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER PROC [dbo].[PSP_NhapHang_LayChiTietNhapHang]--'PN2003010002'
    @MaPhieuNhap CHAR(13) = '0'
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
            g.TenDonViTinh ,
            GiaBanHienHanh
    FROM    dbo.PhieuNhap a
            JOIN dbo.ChiTietPhieuNhap b ON b.MaPhieuNhap = a.MaPhieuNhap
            JOIN dbo.NhanVien c ON c.MaNhanVien = a.MaNhanVien
            JOIN dbo.SanPham d ON d.MaSanPham = b.MaSanPham
            JOIN dbo.LoaiSanPham e ON e.MaLoaiSanPham = d.MaLoaiSanPham
            JOIN dbo.NhaCungCap f ON f.MaNhaCungCap = d.MaNhaCungCap
            JOIN dbo.DonViTinh g ON g.MaDonViTinh = d.MaDonViTinh
            JOIN GiaBan j ON j.MaSanPham = d.MaSanPham
    WHERE   @MaPhieuNhap = CASE @MaPhieuNhap
                             WHEN '0' THEN '0'
                             ELSE a.MaPhieuNhap
                           END
            AND j.IsDelete = 0;
            GO
            ALTER PROC [dbo].[PSP_NhapHang_UpdateChiTietPhieuNhap]
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
@MaNhaCungCap INT ,
@GiaBanHienHanh INT 
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
            
            
    UPDATE GiaBan
    SET IsDelete=1
    WHERE MaSanPham=@MaSanPham   AND IsDelete=0
    
    INSERT INTO GiaBan(MaSanPham,GiaBanHienHanh)
    VALUES(@MaSanPham,@GiaBanHienHanh)
COMMIT
GO
ALTER PROC [dbo].[PSP_NhapHang_LayThongTinSanPhamTheoLoai]
@MaLoaiSanPham INT
AS
SELECT a.MaSanPham, TenSanPham, MoTa, MaDonViTinh, MaLoaiSanPham, MaNhaCungCap, SoLuongTon, DonGiaBinhQuan,GiaBanHienHanh
FROM dbo.SanPham a JOIN giaBan b ON a.MaSanPham=b.MaSanPham
WHERE MaLoaiSanPham=@MaLoaiSanPham AND a.IsDelete=0 AND b.IsDelete=0
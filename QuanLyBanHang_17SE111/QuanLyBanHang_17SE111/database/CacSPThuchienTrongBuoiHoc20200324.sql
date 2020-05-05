--Các thủ tục trong ngày 24-03-2020
IF OBJECT_ID('dbo.PSP_NhanVien_Delete')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhanVien_Delete
END
GO
CREATE PROC dbo.PSP_NhanVien_Delete
@MaNhanVien INT 
AS
DELETE dbo.NHANVIEN
WHERE MaNhanVien=@MaNhanVien
GO
IF OBJECT_ID('dbo.PSP_NhanVien_DeleteByUpdateIsDelete')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhanVien_DeleteByUpdateIsDelete
END
GO
CREATE PROC PSP_NhanVien_DeleteByUpdateIsDelete
@MaNhanVien INT
AS
UPDATE dbo.NhanVien
SET IsDelete=1
WHERE MaNhanVien=@MaNhanVien
GO
IF OBJECT_ID('dbo.[PSP_SaoLuuDuLieu]')IS NOT NULL
BEGIN
    DROP PROC dbo.[PSP_SaoLuuDuLieu]
END
GO
Create proc [dbo].[PSP_SaoLuuDuLieu]
	@duongdan nvarchar(max)
as
begin
	declare @dbname nvarchar(50)
	set @dbname =  DB_NAME()
	BACKUP DATABASE @dbname
	TO  DISK = @duongdan
	WITH NOFORMAT, NOINIT,  
	SKIP, NOREWIND, NOUNLOAD,  STATS = 10
	select ErrorCode = 1
END

GO 
IF OBJECT_ID('dbo.PSP_NhanVien_LayDuLieuCbo')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhanVien_LayDuLieuCbo
END
GO
CREATE PROC PSP_NhanVien_LayDuLieuCbo
AS
SELECT MaNhanVien,TenNhanVien
FROM dbo.NhanVien
WHERE IsDelete=0

GO 
IF OBJECT_ID('dbo.PSP_NhanVien_ResetMatKhau')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhanVien_ResetMatKhau
END
GO
CREATE PROC PSP_NhanVien_ResetMatKhau
@MaNhanVien INT
AS
UPDATE dbo.NhanVien
SET MatKhau=pwdencrypt(TenDangNhap)
WHERE MaNhanVien=@MaNhanVien

GO 
IF OBJECT_ID('dbo.PSP_NhanVien_DoiMatKhau')IS NOT NULL
BEGIN
    DROP PROC dbo.PSP_NhanVien_DoiMatKhau
END
GO
CREATE PROC PSP_NhanVien_DoiMatKhau
@MaNhanVien INT,
@MatKhau VARCHAR(30)
AS
UPDATE dbo.NhanVien
SET MatKhau=pwdencrypt(@MatKhau)
WHERE MaNhanVien=@MaNhanVien
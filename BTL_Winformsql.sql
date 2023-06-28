CREATE DATABASE BTL_Winform

USE BTL_Winform

CREATE TABLE ChiTietHDB
(
MaHDB NVARCHAR(10) foreign key references HoaDonBan(MaHDB)
ON DELETE CASCADE ON UPDATE CASCADE,
MaSP NVARCHAR(10) foreign key references SanPham(MaSP)
ON DELETE CASCADE ON UPDATE CASCADE,
SoLuong INT,
DonGia FLOAT,
GiamGia FLOAT,
ThanhTien FLOAT,
PRIMARY KEY(MaHDB, MaSP)
)

CREATE TABLE TaiKhoan(
UserID nvarchar(25) primary key,
Pass nvarchar(25),
Per int
)

drop table TaiKhoan

CREATE PROC SP_AuthoLogin (
				@tk nvarchar(50), 
				@mk nvarchar(50),
				@role int output
)
AS
BEGIN
	IF(EXISTS(SELECT *
				FROM TaiKhoan
				Where UserID = @tk AND Pass = @mk)) 
	BEGIN
		SELECT @role = Per
		FROM TaiKhoan
		Where UserID = @tk AND Pass = @mk
	END
	ELSE
	BEGIN
		IF(EXISTS(SELECT *
				FROM TaiKhoan
				Where UserID = @tk))
		BEGIN
			SET @role = 3
		END
		ELSE
			SET @role = 4
	END
END


DROP PROC SP_AuthoLogin


DECLARE @quyen INT
EXECUTE SP_AuthoLogin 'dan','1', @role = @quyen output
SELECT @quyen


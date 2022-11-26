-- HOTEN : TRAN VAN lUC     MSSV : 20521587
--TAO DATABASE MUSIC
CREATE DATABASE MUSIC

USE [Shopping]

-- drop table Thongtin
CREATE TABLE THONGTIN(
	MABH		char(4),
	TENBH		nvarchar(50),
	TACGIA		nvarchar(30),
	CASI		nvarchar(30),
	THELOAI		nvarchar(30),
	QUOCGIA		nvarchar(30),
	THOILUONG	time,
);


INSERT INTO THONGTIN VALUES('BH01',N'Tết Nhà Mình',N'Huỳnh Hiền Năng',N'Hòa Minzy',N'Nhạc trẻ',N'Việt Nam','00:03:55');
INSERT INTO THONGTIN VALUES('BH02',N'Ai cần ai',N'Hứa Kim Tuyền',N'Bảo Anh',N'Nhạc trẻ',N'Việt Nam','00:03:24');
delete from THONGTIN where MABH ='BH02'

CREATE TABLE DANHGIA(
	MABH		char(4),
	TEN			nvarchar(50),
	DANHGIA		nvarchar(30),
	rate
	THOIGIAN	smalldatetime,	
);

CREATE TABLE PLAYLIST(
	MAPL		int,
	TENPL		nvarchar(50),
	MABH		char(4),
);
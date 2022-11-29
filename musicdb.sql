-- HOTEN : TRAN VAN lUC     MSSV : 20521587
--TAO DATABASE MUSIC
CREATE DATABASE MUSIC

USE [MUSIC]

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
INSERT INTO THONGTIN VALUES('BH03',N'Cứ Thở Đi',N'Hứa Kim Tuyền',N'Đức Phúc & Juky San',N'Nhạc trẻ',N'Việt Nam','00:03:45');
delete from THONGTIN where MABH ='BH02'

drop table  DANHGIA
CREATE TABLE DANHGIA(
	MABH		char(4),
	SODG		int,
	TEN			nvarchar(50),
	DANHGIA		nvarchar(100),
	rate		int,
	THOIGIAN	smalldatetime,	
	THICH		int,
	KOTHICH		int,
);
SET DATEFORMAT DMY;

INSERT INTO DANHGIA VALUES('BH01','1',N'Nguyễn Tuân',N'Tuiyt zời','5','28/11/2022','100','1');
INSERT INTO DANHGIA VALUES('BH01','2',N'Thúy Kiều',N'Muốn Zề nhà ăn tết ghê','5','25/11/2022','7','1');
INSERT INTO DANHGIA VALUES('BH01','3',N'Thúy Vân',N'Nhớ Tết Quớ','5','20/11/2022','5','1');
INSERT INTO DANHGIA VALUES('BH02','4',N'Nguyễn Du',N'Từ lúc sáng tác truyện kiều chưa thấy bài nào hay như bài này','5','27/11/2022','4','1');

delete from DANHGIA where SODG ='5'

UPDATE DANHGIA SET THICH = 1,KOTHICH = 0 WHERE SODG = @SODG;


-- drop table PLAYLIST

CREATE TABLE PLAYLIST(
	MAPL		int,
	TENPL		nvarchar(50),
	MABH		char(4),
	THOIGIANTAO smalldatetime,
);
INSERT INTO PLAYLIST VALUES('1',N'Playlist của lực','BH01','28/11/2022');


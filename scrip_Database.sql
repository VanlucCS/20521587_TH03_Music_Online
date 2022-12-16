-- HOTEN : TRAN VAN lUC     MSSV : 20521587
--TAO DATABASE MUSIC
CREATE DATABASE MUSIC

USE [MUSIC]
GO
-- drop table Thongtin
CREATE TABLE THONGTIN(
	MABH		char(4),
	TENBH		nvarchar(50),
	TACGIA		nvarchar(50),
	CASI		nvarchar(30),
	THELOAI		nvarchar(30),
	QUOCGIA		nvarchar(30),
	THOILUONG	time,
);
INSERT INTO THONGTIN VALUES('BH01',N'Tết Nhà Mình',N'Huỳnh Hiền Năng',N'Hòa Minzy',N'Nhạc Trẻ',N'Việt Nam','00:03:55');
INSERT INTO THONGTIN VALUES('BH02',N'Ai cần ai',N'Hứa Kim Tuyền',N'Bảo Anh',N'Nhạc Trẻ',N'Việt Nam','00:03:24');
INSERT INTO THONGTIN VALUES('BH03',N'Cứ Thở Đi',N'Hứa Kim Tuyền',N'Đức Phúc & Juky San',N'Nhạc Trẻ',N'Việt Nam','00:03:45');
INSERT INTO THONGTIN VALUES('BH04',N'Running Out Of Roses',N'Alan Walker & Jamie Miller',N'Alan Walker',N'Electronica/Dance',N'Âu Mỹ','00:02:16');
INSERT INTO THONGTIN VALUES('BH05',N'Made You Look',N'Meghan Trainor',N'Meghan Trainor',N'Pop',N'Âu Mỹ','00:02:17');
INSERT INTO THONGTIN VALUES('BH06',N'Rolling In The Deep',N'Adele',N'Adele',N'Pop',N'Âu Mỹ','00:03:47');
INSERT INTO THONGTIN VALUES('BH07',N'Waiting For You',N'Nguyễn Việt Hoàng, Nguyễn Ngọc Hoàng Anh',N'MONO, Onionn',N'Nhạc Trẻ',N'Việt Nam','00:04:25');
INSERT INTO THONGTIN VALUES('BH08',N'Có Đâu Ai Ngờ',N'REDT',N'Thu Cầm',N'Nhạc Trẻ',N'Việt Nam','00:03:40');
INSERT INTO THONGTIN VALUES('BH09',N'Bài Này Không Để Đi Diễn',N'Bùi Công Nam',N'Anh Tú Atus',N'Nhạc Trẻ',N'Việt Nam','00:02:59');
INSERT INTO THONGTIN VALUES('BH10',N'Điều Cha Chưa Nói (Bố Già OST)',N'Trấn Thành',N'Ali Hoàng Dương',N'Nhạc Trẻ',N'Việt Nam','00:04:19');
INSERT INTO THONGTIN VALUES('BH11',N'Em Là Nhất Miền Tây',N'Jin Tuấn Nam',N'Võ Lê Mi, Jin Tuấn Nam',N'Nhạc Trẻ',N'Việt Nam','00:03:07');
INSERT INTO THONGTIN VALUES('BH12',N'Bước Qua Nhau',N'Vũ',N'Vũ',N'Nhạc Trẻ',N'Việt Nam','00:04:18');
INSERT INTO THONGTIN VALUES('BH13',N'Anh Tự Do Nhưng Cô Đơn ',N'Đạt G',N'Trung Quân',N'Nhạc Trẻ',N'Việt Nam','00:05:15');
INSERT INTO THONGTIN VALUES('BH14',N'Cứ Chill Thôi',N'Trần Duy Khang',N'Chillies, Suni Hạ Linh',N'Nhạc Trẻ',N'Việt Nam','00:04:30');
INSERT INTO THONGTIN VALUES('BH15',N'Savage Love',N'Jawsh 685',N'Jason Derulo',N'Electronica/Dance',N'Âu Mỹ','00:02:49');
INSERT INTO THONGTIN VALUES('BH16',N'Tình Cố Hương',N'Hoàng Văn',N'Bảo Nguyên',N'Trữ Tình',N'Việt Nam','00:05:58');
INSERT INTO THONGTIN VALUES('BH17',N'Quê Em Mùa Nước Lũ',N'Tiến Luân',N'Phương Mỹ Chi',N'Trữ Tình',N'Việt Nam','00:05:34');
INSERT INTO THONGTIN VALUES('BH18',N'Áo Mới Cà Mau',N'Thanh Sơn',N'Phương Mỹ Chi',N'Trữ Tình',N'Việt Nam','00:03:49');
INSERT INTO THONGTIN VALUES('BH19',N'Hoa Sứ Nhà Nàng',N'Hoàng Phương',N'Anh Khang',N'Trữ Tình',N'Việt Nam','00:03:43');
INSERT INTO THONGTIN VALUES('BH20',N'Bất Chấp',N'Dư Quốc Vương',N'WHEE!',N'Remix Việt',N'Việt Nam','00:03:04');
INSERT INTO THONGTIN VALUES('BH21',N'Mah Boo',N'Tăng Duy Tân',N'Phạm Việt Thắng',N'Remix Việt',N'Việt Nam','00:03:54');
INSERT INTO THONGTIN VALUES('BH22',N'Replay trên con Guây (ShenlongZ Remix)',N'Phúc Du,Tiên Cookie',N'Phúc Du & Đan Ni',N'Remix Việt',N'Việt Nam','00:03:12');
INSERT INTO THONGTIN VALUES('BH23',N'Say Đắm Trong Lần Đầu (Sped Up)',N'Winno',N'Winno',N'Remix Việt',N'Việt Nam','00:02:04');
INSERT INTO THONGTIN VALUES('BH24',N'Memories',N'Maroon 5',N'Maroon 5',N'Pop',N'Âu Mỹ','00:03:09');
INSERT INTO THONGTIN VALUES('BH25',N'Yummy',N'Justin Bieber, Jason Boyd',N'Justin Bieber',N'Pop',N'Âu Mỹ','00:03:23');
INSERT INTO THONGTIN VALUES('BH26',N'We Dont Talk Anymore',N'Charlie Puth',N'Charlie Puth, Selena Gomez',N'Pop',N'Âu Mỹ','00:03:37');
INSERT INTO THONGTIN VALUES('BH27',N'Girls Like You',N'Adam Levine, ‎Henry Walter',N'Maroon 5, Cardi B',N'Pop',N'Âu Mỹ','00:03:55');
INSERT INTO THONGTIN VALUES('BH28',N'Drive My Car',N'Artemii Besedin',N'Deamn',N'Electronica/Dance',N'Âu Mỹ','00:03:17');
INSERT INTO THONGTIN VALUES('BH29',N'So Far Away',N'David Guetta, Jamie Scott',N'Martin Garrix, David Guetta',N'Electronica/Dance',N'Âu Mỹ','00:03:04');
INSERT INTO THONGTIN VALUES('BH30',N'Something Just Like This',N' Andrew Taggart, Guy Berryman',N'The Chainsmokers, Coldplay',N'Electronica/Dance',N'Âu Mỹ','00:04:07');

--drop table  DANHGIA
CREATE TABLE DANHGIA(
	MABH		char(4),
	SODG		int,
	TEN			nvarchar(50),
	DANHGIA		nvarchar(100),
	rate		float,
	THOIGIAN	smalldatetime,	
	THICH		int,
	KOTHICH		int,
);

SET DATEFORMAT DMY;
INSERT INTO DANHGIA VALUES('BH01','1',N'Nguyễn Tuân',N'Tuiyt zời','5','28/11/2022','12','1');
INSERT INTO DANHGIA VALUES('BH01','2',N'Thúy Kiều',N'Muốn Zề nhà ăn tết ghê','5','25/11/2022','7','1');
INSERT INTO DANHGIA VALUES('BH01','3',N'Thúy Vân',N'Nhớ Tết Quớ','5','20/11/2022','5','1');
INSERT INTO DANHGIA VALUES('BH02','4',N'Nguyễn Du',N'Từ lúc sáng tác truyện kiều chưa thấy bài nào hay như bài này','5','27/11/2022','4','1');
INSERT INTO DANHGIA VALUES('BH06','5',N'Đoán Xem',N'good','4.3','27/11/2022','4','1');

--UPDATE DANHGIA SET THICH = 1,KOTHICH = 0 WHERE SODG = @SODG;
-- drop table PLAYLIST

CREATE TABLE PLAYLIST(
	MAPL		int,
	TENPL		nvarchar(50),
	MABH		char(4),
	THOIGIANTAO smalldatetime,
);
SET DATEFORMAT DMY;
INSERT INTO PLAYLIST VALUES('1',N'Playlist của lực','BH01','28/11/2022');

--drop TABLE USERINFO
CREATE TABLE USERINFO(
	MAUSER			char(4),
	TEN				nvarchar(50),
	USERNAME		nvarchar(50),
	USERPASSWORD	nvarchar(50),
	NGAYTAOTK		smalldatetime,
);
SET DATEFORMAT DMY;
INSERT INTO USERINFO VALUES('US00',N'Đoán Xem','user','user','28/11/2022');
INSERT INTO USERINFO VALUES('US01',N'Nguyễn Tuân','nguyetuan','123123','28/11/2022');
INSERT INTO USERINFO VALUES('US02',N'Thúy Kiều','thuykieu','123123','28/11/2022');
INSERT INTO USERINFO VALUES('US03',N'Thúy Vân','thuyvan','123123','28/11/2022');
INSERT INTO USERINFO VALUES('US04',N'Nguyễn Du','nguyendu','123123','28/11/2022');
INSERT INTO USERINFO VALUES('US05',N'Văn Lực','vanluc','123123','28/11/2022');

CREATE TABLE FAVORITESONG(
	MABH			char(4),
);
INSERT INTO FAVORITESONG VALUES('BH04');
INSERT INTO FAVORITESONG VALUES('BH03');
INSERT INTO FAVORITESONG VALUES('BH06');

--IF NOT EXISTS(SELECT 1 FROM FAVORITESONG WHERE MABH='BH01')
--INSERT INTO FAVORITESONG VALUES('BH01');
--delete from DANHGIA where MABH ='1'

CREATE TABLE LISTENHIS(
	MABH			char(4),
	SOLAN			int,
	THOIGIAN		smalldatetime,
);


SET DATEFORMAT DMY;
INSERT INTO LISTENHIS VALUES('BH04','2','12/11/2022');
INSERT INTO LISTENHIS VALUES('BH01','7','12/11/2022');
INSERT INTO LISTENHIS VALUES('BH02','4','12/11/2022');

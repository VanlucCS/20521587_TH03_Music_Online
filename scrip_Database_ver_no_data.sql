USE [MUSIC]
GO
/****** Object:  Table [dbo].[DANHGIA]    Script Date: 12/16/2022 3:28:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANHGIA](
	[MABH] [char](4) NULL,
	[SODG] [int] NULL,
	[TEN] [nvarchar](50) NULL,
	[DANHGIA] [nvarchar](100) NULL,
	[rate] [float] NULL,
	[THOIGIAN] [smalldatetime] NULL,
	[THICH] [int] NULL,
	[KOTHICH] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAVORITESONG]    Script Date: 12/16/2022 3:28:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAVORITESONG](
	[MABH] [char](4) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LISTENHIS]    Script Date: 12/16/2022 3:28:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LISTENHIS](
	[MABH] [char](4) NULL,
	[SOLAN] [int] NULL,
	[THOIGIAN] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PLAYLIST]    Script Date: 12/16/2022 3:28:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PLAYLIST](
	[MAPL] [int] NULL,
	[TENPL] [nvarchar](50) NULL,
	[MABH] [char](4) NULL,
	[THOIGIANTAO] [smalldatetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THONGTIN]    Script Date: 12/16/2022 3:28:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONGTIN](
	[MABH] [char](4) NULL,
	[TENBH] [nvarchar](50) NULL,
	[TACGIA] [nvarchar](50) NULL,
	[CASI] [nvarchar](30) NULL,
	[THELOAI] [nvarchar](30) NULL,
	[QUOCGIA] [nvarchar](30) NULL,
	[THOILUONG] [time](7) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERINFO]    Script Date: 12/16/2022 3:28:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERINFO](
	[MAUSER] [char](4) NULL,
	[TEN] [nvarchar](50) NULL,
	[USERNAME] [nvarchar](50) NULL,
	[USERPASSWORD] [nvarchar](50) NULL,
	[NGAYTAOTK] [smalldatetime] NULL
) ON [PRIMARY]
GO

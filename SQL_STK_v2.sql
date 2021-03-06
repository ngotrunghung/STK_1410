USE [master]
GO
/****** Object:  Database [db_Money]    Script Date: 14-10-2018 10:55:52 PM ******/
CREATE DATABASE [db_Money]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_Money', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_Money.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_Money_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_Money_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_Money] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_Money].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_Money] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_Money] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_Money] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_Money] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_Money] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_Money] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_Money] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [db_Money] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_Money] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_Money] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_Money] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_Money] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_Money] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_Money] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_Money] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_Money] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_Money] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_Money] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_Money] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_Money] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_Money] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_Money] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_Money] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_Money] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_Money] SET  MULTI_USER 
GO
ALTER DATABASE [db_Money] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_Money] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_Money] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_Money] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [db_Money]
GO
/****** Object:  Table [dbo].[NganHang]    Script Date: 14-10-2018 10:55:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NganHang](
	[MaNganHang] [varchar](5) NOT NULL,
	[TenNganHang] [varchar](20) NULL,
 CONSTRAINT [PK_NganHang] PRIMARY KEY CLUSTERED 
(
	[MaNganHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 14-10-2018 10:55:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[ID] [varchar](150) NOT NULL,
	[MK] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TheTietKiem]    Script Date: 14-10-2018 10:55:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TheTietKiem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaSo] [varchar](10) NULL,
	[Email] [varchar](150) NOT NULL,
	[MaNganHang] [varchar](5) NOT NULL,
	[NgayGui] [date] NULL,
	[SoTienGui] [float] NULL,
	[LaiSuat] [float] NULL,
	[KhiDenHan] [nvarchar](50) NULL,
	[TraLai] [nvarchar](50) NULL,
	[KyHan] [nvarchar](30) NULL,
	[LaiKhongKyHan] [float] NULL,
	[TatToan] [bit] NULL,
	[TienLai] [float] NULL,
 CONSTRAINT [PK_TheTietKiem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[NganHang] ([MaNganHang], [TenNganHang]) VALUES (N'BIDV', N'BIDV')
INSERT [dbo].[NganHang] ([MaNganHang], [TenNganHang]) VALUES (N'FE', N'FE CREADIT')
INSERT [dbo].[NganHang] ([MaNganHang], [TenNganHang]) VALUES (N'HOME', N'HOME CREADIT')
INSERT [dbo].[NganHang] ([MaNganHang], [TenNganHang]) VALUES (N'SCB', N'SACOMBANK')
INSERT [dbo].[NganHang] ([MaNganHang], [TenNganHang]) VALUES (N'VCB', N'VIETCOM BANK')
INSERT [dbo].[NganHang] ([MaNganHang], [TenNganHang]) VALUES (N'VTB', N'VIETTIN BANK')
INSERT [dbo].[TaiKhoan] ([ID], [MK]) VALUES (N'', NULL)
INSERT [dbo].[TaiKhoan] ([ID], [MK]) VALUES (N'dev01@gmail.com', N'Hung5055.')
INSERT [dbo].[TaiKhoan] ([ID], [MK]) VALUES (N'dev02@hotmail.com', N'Hung5055.')
SET IDENTITY_INSERT [dbo].[TheTietKiem] ON 

INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (4, N'VCB_', N'dev01@gmail.com', N'VCB', CAST(N'2018-02-01' AS Date), 80000000, 4.6, N'Tất toán sổ', N'Đầu kỳ', N'1 tháng', 0.3, 1, NULL)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (10, N'HOME_001', N'dev01@gmail.com', N'HOME', CAST(N'2018-02-01' AS Date), 4600000, 1.5, N'Tái tục gốc và lãi', N'Đầu kỳ', N'Không kỳ hạn', 1.5, 1, 0)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (2016, N'VCB_001', N'dev01@gmail.com', N'VCB', CAST(N'2017-01-02' AS Date), 35000000, 2.9, N'Tái tục gốc', N'Đầu kỳ', N'6 tháng', 0.5, 1, 0)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (2017, N'SCB_001', N'dev01@gmail.com', N'SCB', CAST(N'2018-06-05' AS Date), 50000000, 2.5, N'Tái tục gốc', N'Đầu kỳ', N'3 tháng', 0.5, 1, 0)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (2018, N'SCB_002', N'dev01@gmail.com', N'SCB', CAST(N'2018-01-01' AS Date), 64900000, 5.56, N'Tái tục gốc và lãi', N'Đầu kỳ', N'1 tháng', 0.5, 0, 30116666.6666667)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (2019, N'HOME_001', N'dev01@gmail.com', N'HOME', CAST(N'2018-09-03' AS Date), 2000000, 1, N'Tái tục gốc', N'Cuối Kỳ', N'12 tháng', 0.5, 0, 2000000)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (3016, N'SCB_101', N'dev01@gmail.com', N'SCB', CAST(N'2018-10-01' AS Date), 1300000, 1.5, N'Tái tục gốc', N'Đầu kỳ', N'6 tháng', 0.5, 0, 750000)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (3017, N'VTB_001', N'dev01@gmail.com', N'VTB', CAST(N'2018-09-06' AS Date), 3000000, 2, N'Tái tục gốc', N'Đầu kỳ', N'6 tháng', 0.05, 0, 75000)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (3018, N'VCB_003', N'dev01@gmail.com', N'VCB', CAST(N'2018-10-10' AS Date), 1000000, 5.3, N'Tái tục gốc', N'Định kỳ hàng tháng', N'Không kỳ hạn', 0.05, 0, NULL)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (3019, N'SCB_123', N'dev01@gmail.com', N'SCB', CAST(N'2018-06-15' AS Date), 2400000, 1.6, N'Tái tục gốc', N'Cuối Kỳ', N'Không kỳ hạn', 0.05, 0, NULL)
INSERT [dbo].[TheTietKiem] ([ID], [MaSo], [Email], [MaNganHang], [NgayGui], [SoTienGui], [LaiSuat], [KhiDenHan], [TraLai], [KyHan], [LaiKhongKyHan], [TatToan], [TienLai]) VALUES (3020, N'FE_001', N'dev01@gmail.com', N'FE', CAST(N'2018-04-05' AS Date), 4000000, 5.2, N'Tái tục gốc', N'Cuối Kỳ', N'3 tháng', 0.05, 0, NULL)
SET IDENTITY_INSERT [dbo].[TheTietKiem] OFF
ALTER TABLE [dbo].[TheTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_TheTietKiem_NganHang] FOREIGN KEY([MaNganHang])
REFERENCES [dbo].[NganHang] ([MaNganHang])
GO
ALTER TABLE [dbo].[TheTietKiem] CHECK CONSTRAINT [FK_TheTietKiem_NganHang]
GO
ALTER TABLE [dbo].[TheTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_TheTietKiem_TaiKhoan] FOREIGN KEY([Email])
REFERENCES [dbo].[TaiKhoan] ([ID])
GO
ALTER TABLE [dbo].[TheTietKiem] CHECK CONSTRAINT [FK_TheTietKiem_TaiKhoan]
GO
USE [master]
GO
ALTER DATABASE [db_Money] SET  READ_WRITE 
GO

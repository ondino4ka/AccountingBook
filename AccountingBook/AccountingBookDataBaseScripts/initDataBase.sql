USE [master]
GO
/****** Object:  Database [AccountingBookDB]    Script Date: 25.11.2017 18:10:56 ******/
CREATE DATABASE [AccountingBookDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AccountingBookDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AccountingBookDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AccountingBookDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\AccountingBookDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AccountingBookDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AccountingBookDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AccountingBookDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AccountingBookDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AccountingBookDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AccountingBookDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AccountingBookDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AccountingBookDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AccountingBookDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AccountingBookDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AccountingBookDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AccountingBookDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AccountingBookDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AccountingBookDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AccountingBookDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AccountingBookDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AccountingBookDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AccountingBookDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AccountingBookDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AccountingBookDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AccountingBookDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AccountingBookDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AccountingBookDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AccountingBookDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AccountingBookDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AccountingBookDB] SET  MULTI_USER 
GO
ALTER DATABASE [AccountingBookDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AccountingBookDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AccountingBookDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AccountingBookDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AccountingBookDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AccountingBookDB]
GO
/****** Object:  User [accbook]    Script Date: 25.11.2017 18:10:56 ******/
CREATE USER [accbook] FOR LOGIN [accbook] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [accbook]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[idCategory] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locations]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[idLocation] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Location_1] PRIMARY KEY CLUSTERED 
(
	[idLocation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[States]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[idState] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[idState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubCategories]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategories](
	[idSubCategory] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[idCategory] [int] NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[idSubCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[inventoryNumber] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[idState] [int] NOT NULL,
	[idSubCategory] [int] NOT NULL,
	[Photo] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[idLocation] [int] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[inventoryNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
INSERT [dbo].[Categories] ([idCategory], [Name]) VALUES (1, N'Electronics')
GO
INSERT [dbo].[Categories] ([idCategory], [Name]) VALUES (2, N'Appliances')
GO
INSERT [dbo].[Categories] ([idCategory], [Name]) VALUES (3, N'Furniture')
GO
INSERT [dbo].[Categories] ([idCategory], [Name]) VALUES (4, N'The electrotool')
GO
INSERT [dbo].[Categories] ([idCategory], [Name]) VALUES (5, N'Sanitary engineering')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

GO
INSERT [dbo].[Locations] ([idLocation], [Address]) VALUES (1, N'Mogilev, Pushkin Ave., 7')
GO
INSERT [dbo].[Locations] ([idLocation], [Address]) VALUES (2, N'Mogilev, Romanova, 23')
GO
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 

GO
INSERT [dbo].[States] ([idState], [StateName]) VALUES (1, N'Будет приобретен')
GO
INSERT [dbo].[States] ([idState], [StateName]) VALUES (2, N'Working')
GO
INSERT [dbo].[States] ([idState], [StateName]) VALUES (3, N'Decommissioned')
GO
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategories] ON 

GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (1, N'Monitors', 1)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (2, N'Phones', 1)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (4, N'Cameras', 1)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (5, N'Refrigerators', 2)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (6, N'Hoods', 2)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (7, N'Kitchen stoves', 2)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (11, N'Sofas', 3)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (12, N'Tables', 3)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (13, N'Chairs', 3)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (14, N'Drills', 4)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (15, N'Welders', 4)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (16, N'Toilets', 5)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (17, N'Washbasins', 5)
GO
INSERT [dbo].[SubCategories] ([idSubCategory], [Name], [idCategory]) VALUES (18, N'Baths', 5)
GO
SET IDENTITY_INSERT [dbo].[SubCategories] OFF
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (1, N'LG 43UJ639V', 1, 1, N'https://avatars.mds.yandex.net/get-mpic/195452/img_id6827025122946540772/orig', N'Very good tv', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (2, N'Samsung UE22H5600', 1, 1, N'https://avatars.mds.yandex.net/get-mpic/200316/img_id7148496232302937310/orig', N'Nice tv', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (3, N'Sony Xperia P', 1, 2, N'https://avatars.mds.yandex.net/get-mpic/195452/img_id3100006917154969440/orig', N'very nice phone', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (4, N'Sony Xperia Z3', 1, 2, N'https://avatars.mds.yandex.net/get-mpic/96484/img_id3008615484850637072/orig', N'Very very good phone', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (5, N'Canon EOS 1300D Kit', 2, 4, N'https://avatars.mds.yandex.net/get-mpic/195452/img_id7948107280802676417/orig', N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (6, N'Canon PowerShot SX620 HS', 3, 4, N'https://avatars.mds.yandex.net/get-mpic/195452/img_id3009300450598592384/orig', N'good camera', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (7, N'ATLANT М 7184-003', 2, 5, N'https://avatars.mds.yandex.net/get-mpic/200316/img_id465623648100938606/orig', N'good refregeration', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (8, N'"ATLANT М 7204-100', 1, 5, N'https://avatars.mds.yandex.net/get-mpic/96484/img_id3763531369097749738/orig', N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (9, N'GERMES Stash plus 60 AL', 2, 6, N'https://avatars.mds.yandex.net/get-mpic/199079/img_id6440082672219637460/orig', N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (10, N'GERMES Stash plus 60 IX', 3, 6, N'https://avatars.mds.yandex.net/get-mpic/199079/img_id4458285398250739306/orig', N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (11, N'GEFEST 6502-02 0045', 1, 7, N'https://avatars.mds.yandex.net/get-mpic/96484/img_id2040365954788044981/orig', N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (12, N'GEFEST 3200-08', 2, 7, N'https://avatars.mds.yandex.net/get-mpic/397397/img_id5180371151626122523.jpeg/orig', N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (13, N'Ikea Colsta', 1, 11, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (14, N'Intex Kriss', 1, 11, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (15, N'Halmar 3000', 3, 12, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (16, N'Halmar 5000', 2, 12, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (17, N'Metta BK-8CH', 3, 13, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (18, N'Metta AA-8CH', 3, 13, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (19, N'Bosh GSP L123', 1, 14, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (20, N'Bosh GSP L321', 2, 14, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (21, N'Solaris MMA-208', 2, 15, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (22, N'Spark MasterARC 200', 1, 15, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (23, N'Keramin Ultra', 1, 16, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (24, N'Keramin Ultra2', 1, 16, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (25, N'Roca Berna', 1, 17, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (26, N'Roca Diverta', 2, 17, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (27, N'Triton 2000', 1, 18, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idSubCategory], [Photo], [Description], [idLocation]) VALUES (28, N'Paisiedon 3000"', 1, 18, NULL, N'description', 1)
GO
ALTER TABLE [dbo].[SubCategories]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([idCategory])
REFERENCES [dbo].[Categories] ([idCategory])
GO
ALTER TABLE [dbo].[SubCategories] CHECK CONSTRAINT [FK_SubCategory_Category]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subject_State] FOREIGN KEY([idState])
REFERENCES [dbo].[States] ([idState])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subject_State]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subject_SubCategory] FOREIGN KEY([idSubCategory])
REFERENCES [dbo].[SubCategories] ([idSubCategory])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subject_SubCategory]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Locations] FOREIGN KEY([idLocation])
REFERENCES [dbo].[Locations] ([idLocation])
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Locations]
GO
/****** Object:  StoredProcedure [dbo].[SelectCategories]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectCategories]
AS
BEGIN
SELECT [idCategory],[Name]
FROM [dbo].[Categories]
END

GO
/****** Object:  StoredProcedure [dbo].[SelectSubCategories]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectSubCategories]
AS
SELECT [idSubCategory],[Name],[idCategory]
FROM [dbo].[SubCategories]

GO
/****** Object:  StoredProcedure [dbo].[SelectSubCategoriesByCategoryId]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectSubCategoriesByCategoryId]
(
@categoryId int
)
AS
SELECT [idSubCategory]
      ,[Name]
      ,[idCategory]
  FROM [dbo].[SubCategories]
  WHERE SubCategories.idCategory = @categoryId 

GO
/****** Object:  StoredProcedure [dbo].[SelectSubjectInformationById]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectSubjectInformationById]
(
@inventoryNumber int
)
AS
BEGIN
SELECT        dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.States.StateName, dbo.Categories.Name AS CategoryName, dbo.SubCategories.Name AS SubCategoryName, dbo.Subjects.Photo, dbo.Subjects.Description, 
                         dbo.Locations.Address
FROM            dbo.Subjects INNER JOIN
                         dbo.SubCategories ON dbo.Subjects.idSubCategory = dbo.SubCategories.idSubCategory INNER JOIN
                         dbo.Locations ON dbo.Subjects.idLocation = dbo.Locations.idLocation INNER JOIN
                         dbo.States ON dbo.Subjects.idState = dbo.States.idState INNER JOIN
                         dbo.Categories ON dbo.SubCategories.idCategory = dbo.Categories.idCategory
WHERE dbo.Subjects.inventoryNumber = @inventoryNumber
END

GO
/****** Object:  StoredProcedure [dbo].[SelectSubjects]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectSubjects]
AS
SELECT [inventoryNumber]
      ,[Name]
      ,[idState]
      ,[idSubCategory]
      ,[Photo]
      ,[Description]
      ,[idLocation]
  FROM [dbo].[Subjects]

GO
/****** Object:  StoredProcedure [dbo].[SelectSubjectsByCategoryId]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectSubjectsByCategoryId]
(
@categoryId int
)
AS
BEGIN
SELECT        dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description
FROM            dbo.Subjects INNER JOIN
                         dbo.SubCategories ON dbo.Subjects.idSubCategory = dbo.SubCategories.idSubCategory INNER JOIN
                         dbo.Categories ON dbo.SubCategories.idCategory = dbo.Categories.idCategory
WHERE        dbo.Categories.idCategory = @categoryId
END

GO
/****** Object:  StoredProcedure [dbo].[SelectSubjectsBySubCategoryId]    Script Date: 25.11.2017 18:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SelectSubjectsBySubCategoryId]
(
@subCategoryId int
)
AS
BEGIN
SELECT        inventoryNumber, Name, Photo, Description
FROM            dbo.Subjects
WHERE        idSubCategory = @subCategoryId
END

GO
USE [master]
GO
ALTER DATABASE [AccountingBookDB] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [AccountingBookDB]    Script Date: 25.12.2017 15:22:10 ******/
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
ALTER DATABASE [AccountingBookDB] SET ENABLE_BROKER
GO
USE [AccountingBookDB]
GO
/****** Object:  User [accbook]    Script Date: 25.12.2017 15:22:11 ******/
CREATE USER [accbook] FOR LOGIN [accbook] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [accbook]
GO
/****** Object:  UserDefinedTableType [dbo].[intTable]    Script Date: 25.12.2017 15:22:11 ******/
CREATE TYPE [dbo].[intTable] AS TABLE(
	[id] [int] NULL
)
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[idCategory] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locations]    Script Date: 25.12.2017 15:22:11 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[States]    Script Date: 25.12.2017 15:22:11 ******/
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
/****** Object:  Table [dbo].[SubCategories]    Script Date: 25.12.2017 15:22:11 ******/
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
/****** Object:  Table [dbo].[Subjects]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[inventoryNumber] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[idState] [int] NULL,
	[idCategory] [int] NULL,
	[Photo] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[idLocation] [int] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[inventoryNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersRoles]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersRoles](
	[idUser] [int] NOT NULL,
	[idRole] [int] NOT NULL,
 CONSTRAINT [PK_UsersRoles] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC,
	[idRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (1, NULL, N'Electronics')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (2, NULL, N'Appliances')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (3, NULL, N'Furniture')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (4, NULL, N'The electrotool')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (5, NULL, N'Sanitary engineering')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (6, 1, N'Monitors')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (7, 1, N'Phones')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (8, 1, N'Cameras')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (9, 2, N'Refrigerators')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (10, 2, N'Hoods')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (11, 2, N'Kitchen stoves')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (12, 3, N'Sofas')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (13, 3, N'Tables')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (14, 3, N'Chairs')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (15, 4, N'Drills')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (16, 4, N'Welders')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (17, 5, N'Toilets')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (18, 5, N'Washbasins')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (19, 5, N'Baths')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (20, 7, N'Sony')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (21, 7, N'Iphone')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (22, 7, N'Samsung')
GO
INSERT [dbo].[Categories] ([idCategory], [pid], [Name]) VALUES (23, 20, N'Xperia')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

GO
INSERT [dbo].[Locations] ([idLocation], [Address]) VALUES (1, N'Mogilev, Pushkin Ave., 8')
GO
INSERT [dbo].[Locations] ([idLocation], [Address]) VALUES (2, N'Mogilev, Romanova, 23')
GO
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

GO
INSERT [dbo].[Roles] ([idRole], [Name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([idRole], [Name]) VALUES (2, N'Edit')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 

GO
INSERT [dbo].[States] ([idState], [StateName]) VALUES (1, N'Will be get')
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
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (1, N'LG 43UJ639V', NULL, 6, N'1.png', N'Very good tv', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (2, N'Samsung UE22H5600', 1, 6, N'2.png', N'Nice tv', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (3, N'Sony Xperia P', 1, 23, N'3.png', N'very nice phone', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (4, N'Sony Xperia Z3', 1, 23, N'4.png', N'Very very good phone', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (5, N'Canon EOS 1300D Kit', 2, 8, N'5.png', N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (6, N'Canon PowerShot SX620 HS', 3, 8, N'6.png', N'good camera', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (7, N'ATLANT Ì 7184-003', 1, 9, N'7.png', N'good refregeration', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (8, N'"ATLANT Ì 7204-100', 1, 9, N'8.png', N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (9, N'GERMES Stash plus 60 AL', 2, 10, N'9.png', N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (10, N'GERMES Stash plus 60 IX', 3, 10, N'10.png', N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (11, N'GEFEST 6502-02 0045', 1, 11, N'11.png', N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (12, N'GEFEST 3200-08', 2, 11, N'12.png', N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (13, N'Ikea Colsta', 1, 12, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (14, N'Intex Kriss', 1, 12, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (15, N'Halmar 3000', 3, 13, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (16, N'Halmar 5000', 2, 13, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (17, N'Metta BK-8CH', 3, 14, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (18, N'Metta AA-8CH', 3, 14, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (19, N'Bosh GSP L123', 1, 15, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (20, N'Bosh GSP L321', 2, 15, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (21, N'Solaris MMA-208', 2, 16, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (22, N'Spark MasterARC 200', 1, 16, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (23, N'Keramin Ultra', 1, 17, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (24, N'Keramin Ultra2', 1, 17, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (25, N'Roca Berna', 1, 18, NULL, N'description', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (26, N'Roca Diverta', 2, 18, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (27, N'Triton 2000', 1, 19, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (28, N'Paisiedon 3000', 1, 19, NULL, N'description', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (29, N'Iphone X', 2, 21, NULL, N'iphone x', 2)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (30, N'Samsung 7s', 1, 22, NULL, N'samsung', 1)
GO
INSERT [dbo].[Subjects] ([inventoryNumber], [Name], [idState], [idCategory], [Photo], [Description], [idLocation]) VALUES (31, N'test', NULL, NULL, NULL, N'1231', NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([idUser], [Name], [Password], [Email]) VALUES (1, N'kostya', N'123456', N'kostik.cirotkin@yandex.ru')
GO
INSERT [dbo].[Users] ([idUser], [Name], [Password], [Email]) VALUES (2, N'maxim', N'123456', N'maxim-dollar@yandex.ru')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UsersRoles] ([idUser], [idRole]) VALUES (1, 1)
GO
INSERT [dbo].[UsersRoles] ([idUser], [idRole]) VALUES (1, 2)
GO
INSERT [dbo].[UsersRoles] ([idUser], [idRole]) VALUES (2, 2)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameUnique]    Script Date: 25.12.2017 15:22:11 ******/
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [RoleNameUnique] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [NameUnique]    Script Date: 25.12.2017 15:22:11 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [NameUnique] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([pid])
REFERENCES [dbo].[Categories] ([idCategory])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subject_State] FOREIGN KEY([idState])
REFERENCES [dbo].[States] ([idState])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subject_State]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Categories] FOREIGN KEY([idCategory])
REFERENCES [dbo].[Categories] ([idCategory])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Categories]
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_Subjects_Locations] FOREIGN KEY([idLocation])
REFERENCES [dbo].[Locations] ([idLocation])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_Subjects_Locations]
GO
ALTER TABLE [dbo].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Roles] FOREIGN KEY([idRole])
REFERENCES [dbo].[Roles] ([idRole])
GO
ALTER TABLE [dbo].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Roles]
GO
ALTER TABLE [dbo].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Users] FOREIGN KEY([idUser])
REFERENCES [dbo].[Users] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersRoles] CHECK CONSTRAINT [FK_UsersRoles_Users]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [PidNotEqualId] CHECK  (([Categories].[pid]<>[Categories].[idCategory]))
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [PidNotEqualId]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategoryById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategoryById]
(
@categoryId int
)
AS
BEGIN
with Recursion
as
(
select idCategory, pid, name
from Categories
where  idCategory = @categoryId
union all
select c.idCategory, c.pid,c.name
FROM Categories c INNER JOIN Recursion r ON c.pid = r.idCategory
)
delete from Categories
where idCategory in (select idCategory from Recursion)
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteLocationById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteLocationById]
(
@locationId int
)
AS
BEGIN
DELETE FROM Locations
WHERE Locations.idLocation = @locationId
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteStateById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStateById]
(
@stateId int
)
AS
BEGIN
DELETE FROM States
WHERE States.idState = @stateId
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteSubjectByInventoryNumber]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSubjectByInventoryNumber]
(
@inventoryNumber int
)
AS
BEGIN
DELETE FROM Subjects
WHERE Subjects.inventoryNumber = @inventoryNumber
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUserById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUserById]
(
@userId int
)
AS
BEGIN
DELETE FROM Users
WHERE Users.idUser = @userId
END

GO
/****** Object:  StoredProcedure [dbo].[InsertCategory]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCategory]
(
@pid int = null,
@categoryName nvarchar(50)
)
AS
BEGIN
INSERT INTO Categories 
VALUES (@pid, @categoryName)
END

GO
/****** Object:  StoredProcedure [dbo].[InsertLocation]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertLocation]
(
@address nvarchar(100)
)
AS
BEGIN
INSERT INTO Locations
VALUES (@address)
END

GO
/****** Object:  StoredProcedure [dbo].[InsertState]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertState]
(
@stateName nvarchar(50)
)
AS
BEGIN
INSERT INTO States
VALUES (@stateName)
END

GO
/****** Object:  StoredProcedure [dbo].[InsertSubject]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSubject]
(
 @inventoryNumber int,
 @name nvarchar(50),
 @stateId int = null,
 @categoryId int = null,
 @photo nvarchar(256) = null,
 @description nvarchar(max),
 @locationId int = null
)
AS
BEGIN   
INSERT INTO Subjects
VALUES (@inventoryNumber, @name, @stateId, @categoryId, @photo, @description, @locationId)
END

GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUser]
(
 @ids intTable READONLY,
 @name nvarchar(50),
 @passwrod nvarchar(max),
 @email nvarchar (255)
)
AS
BEGIN   
    DECLARE @lastId int
    INSERT into dbo.Users 
	VALUES (@name, @passwrod, @email) 
	SET @lastId = (SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY])

	INSERT INTO dbo.UsersRoles
	SELECT @lastId, id FROM @ids

END

GO
/****** Object:  StoredProcedure [dbo].[IsExistSubject]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsExistSubject]
(
@inventoryNumber int
)
AS
BEGIN
IF EXISTS (SELECT Subjects.inventoryNumber FROM Subjects WHERE Subjects.inventoryNumber = @inventoryNumber)
RETURN 1
ELSE 
RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[IsExistsUser]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsExistsUser]
(
@userName nvarchar (50),
@userId int = 0
)
AS
BEGIN
IF EXISTS (SELECT Users.idUser FROM Users WHERE Users.Name = @userName AND Users.idUser <> @userId)
RETURN 1
ELSE 
RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[IsValidUser]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsValidUser]
(
@userName nvarchar (50),
@password nvarchar (max)
)
AS
BEGIN
IF EXISTS (SELECT Users.idUser FROM Users WHERE Users.Name = @userName and Users.Password = @password)
RETURN 1
ELSE 
RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[SelectCategories]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectCategories]
AS
BEGIN
SELECT [idCategory], [pid], [Name]
FROM [dbo].[Categories]
END

GO
/****** Object:  StoredProcedure [dbo].[SelectCategoriesBesidesCurrent]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectCategoriesBesidesCurrent]
(
@categoryId int
)
AS
BEGIN
SELECT [idCategory], [pid], [Name]
FROM [dbo].[Categories]
WHERE idCategory <> @categoryId
END

GO
/****** Object:  StoredProcedure [dbo].[SelectCategoriesByName]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectCategoriesByName]
(
@categoryName nvarchar (50) = null
)
AS
BEGIN
SELECT Categories.idCategory, Categories.Name
FROM Categories
WHERE Categories.Name LIKE ISNULL('%' + @categoryName +'%', '%')
END

GO
/****** Object:  StoredProcedure [dbo].[SelectCategoryById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectCategoryById]
(
@categoryId int
)

AS
BEGIN
SELECT Categories.idCategory,  Categories.pid, Categories.Name
FROM Categories
WHERE Categories.idCategory = @categoryId
END

GO
/****** Object:  StoredProcedure [dbo].[SelectLocationById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectLocationById]
(
@idLocation int 
)

AS
BEGIN
SELECT Locations.idLocation, Locations.Address
FROM Locations
WHERE Locations.idLocation = @idLocation
END

GO
/****** Object:  StoredProcedure [dbo].[SelectLocations]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectLocations]

AS
BEGIN
SELECT Locations.idLocation, Locations.Address
FROM Locations
END

GO
/****** Object:  StoredProcedure [dbo].[SelectLocationsByAddress]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectLocationsByAddress]
(
@address nvarchar(100) = null
)

AS
BEGIN
SELECT Locations.idLocation, Locations.Address
FROM Locations
WHERE Locations.Address LIKE ISNULL('%' + @address + '%', '%')
END

GO
/****** Object:  StoredProcedure [dbo].[SelectRoles]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectRoles]
AS
BEGIN
SELECT Roles.idRole, Roles.Name
FROM Roles
END

GO
/****** Object:  StoredProcedure [dbo].[SelectRolesAuthorizationByUserId]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectRolesAuthorizationByUserId]
(
@userId int
)
AS
BEGIN
SELECT Roles.Name
FROM UsersRoles INNER JOIN Roles ON UsersRoles.idRole = Roles.idRole
WHERE UsersRoles.idUser = @userId
END

GO
/****** Object:  StoredProcedure [dbo].[SelectRolesIdByUserId]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectRolesIdByUserId]
(
@userId int
)
AS
BEGIN
SELECT UsersRoles.idRole 
FROM UsersRoles
WHERE UsersRoles.idUser = @userId
END

GO
/****** Object:  StoredProcedure [dbo].[SelectsSubjectsByName]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectsSubjectsByName]
(
@name nvarchar (50) = NULL
)
AS
BEGIN
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description 
FROM  Subjects 		 
WHERE dbo.Subjects.Name LIKE ISNULL('%' + @name + '%','%')
END

GO
/****** Object:  StoredProcedure [dbo].[SelectStateById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStateById]
(
@stateId int
)
AS
BEGIN
SELECT States.idState, States.StateName
FROM States
WHERE States.idState = @stateId
END

GO
/****** Object:  StoredProcedure [dbo].[SelectStates]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStates]
AS
BEGIN
SELECT States.idState, States.StateName
FROM States
END

GO
/****** Object:  StoredProcedure [dbo].[SelectSubjectByInventoryNumber]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectSubjectByInventoryNumber]
(
@inventoryNumber int
)
AS
BEGIN
SELECT [inventoryNumber]
      ,[Name]
      ,[idState]
      ,[idCategory]
      ,[Description]
	  ,[Photo]
      ,[idLocation]
  FROM [dbo].[Subjects]
  WHERE inventoryNumber = @inventoryNumber
END

GO
/****** Object:  StoredProcedure [dbo].[SelectSubjectByNameCategoryIdAndStateId]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectSubjectByNameCategoryIdAndStateId]
(
@subjectName nvarchar(50) = null,
@idState int = null,
@categoryId int = null
)
AS
BEGIN
if @categoryId is not null and @categoryId <> 0
BEGIN
with Recursion
as
(
select idCategory, pid, name
from Categories
where  idCategory = @categoryId
union all
select c.idCategory, c.pid,c.name
FROM Categories c INNER JOIN Recursion r ON c.pid = r.idCategory
)
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description, dbo.Subjects.idCategory
FROM  (SELECT r.idCategory
From Recursion r) r1 INNER JOIN Subjects ON r1.idCategory = Subjects.idCategory
WHERE Subjects.Name LIKE isnull('%' + @subjectName + '%', '%')
 and ((@idState = 0 and Subjects.idState <> @idState) or Subjects.idState = @idState or (Subjects.idState is null and @idState is null))
END
ELSE
BEGIN
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description, dbo.Subjects.idCategory
FROM  Subjects
WHERE Subjects.Name LIKE isnull('%' + @subjectName + '%', '%')
 and ((@idState = 0 and Subjects.idState <> @idState) or Subjects.idState = @idState or (Subjects.idState is null and @idState is null))
 and  ((@categoryId is null and Subjects.idCategory is null) or (@categoryId = 0 and Subjects.idCategory <> @categoryId))
END
END
GO
/****** Object:  StoredProcedure [dbo].[SelectSubjectInformationById]    Script Date: 25.12.2017 15:22:11 ******/
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
SELECT        dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.States.StateName, dbo.Categories.Name AS Expr1, dbo.Subjects.Photo, dbo.Subjects.Description, dbo.Locations.Address
FROM            dbo.Categories RIGHT JOIN
                         dbo.Subjects ON dbo.Categories.idCategory = dbo.Subjects.idCategory LEFT JOIN
                         dbo.States ON dbo.Subjects.idState = dbo.States.idState LEFT JOIN
                         dbo.Locations ON dbo.Subjects.idLocation = dbo.Locations.idLocation
WHERE dbo.Subjects.inventoryNumber = @inventoryNumber
END

GO
/****** Object:  StoredProcedure [dbo].[SelectSubjectsByCategoryId]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectSubjectsByCategoryId]
(
@categoryId int
)
AS
BEGIN
if @categoryId is not null
BEGIN
with Recursion
as
(
select idCategory, pid, name
from Categories
where  idCategory = @categoryId
union all
select c.idCategory, c.pid, c.name
FROM Categories c INNER JOIN Recursion r ON c.pid = r.idCategory
)
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description 
FROM  (SELECT r.idCategory
From Recursion r) r1 INNER JOIN Subjects ON r1.idCategory = Subjects.idCategory
END
ELSE
BEGIN
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description 
FROM  Subjects
WHERE Subjects.idCategory IS NULL
END
end

GO
/****** Object:  StoredProcedure [dbo].[SelectUserById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectUserById]
(
@userId int
)
AS
BEGIN
SELECT *
FROM Users
WHERE Users.idUser = @userId
END

GO
/****** Object:  StoredProcedure [dbo].[SelectUserByName]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectUserByName]
(
@userName nvarchar(50)
)

AS
BEGIN
SELECT Users.idUser, Users.Name, Users.Email
FROM Users
WHERE Users.name = @userName
END

GO
/****** Object:  StoredProcedure [dbo].[SelectUsersByName]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectUsersByName]
(
@userName nvarchar(50)= null
)
AS
BEGIN
SELECT *
FROM Users
WHERE Users.Name LIKE ISNULL('%' + @userName + '%', '%')
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCategoryById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCategoryById]
(
@categoryId int,
@pid int,
@categoryName nvarchar(50)
)
AS
BEGIN
UPDATE Categories
SET Categories.pid = @pid, Categories.Name = @categoryName
WHERE Categories.idCategory = @categoryId
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateLocationById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLocationById]
(
@locationId int,
@address nvarchar(100)
)
AS
BEGIN
UPDATE Locations 
SET Address = @address
WHERE idLocation = @locationId
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateStateById]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStateById]
(
@stateId int,
@stateName nvarchar(50)
)
AS
BEGIN
UPDATE States
SET StateName = @stateName
WHERE idState = @stateId
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateSubjectInformation]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSubjectInformation]
(
 @inventoryNumber int,
 @name nvarchar(50),
 @stateId int = null,
 @categoryId int = null,
 @description nvarchar(max),
 @locationId int = null
)
AS
BEGIN 
    UPDATE Subjects SET
     Subjects.Name = @name,
	 Subjects.idState = @stateId,
	 Subjects.idCategory = @categoryId,
	 Subjects.Description = @description,
	 Subjects.idLocation = @locationId
    WHERE Subjects.inventoryNumber = @inventoryNumber
END


GO
/****** Object:  StoredProcedure [dbo].[UpdateSubjectPhoto]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSubjectPhoto]
(
@inventoryNumber int,
@photo nvarchar(256)
)
AS
BEGIN
    UPDATE Subjects SET
     Subjects.Photo = @photo
    WHERE Subjects.inventoryNumber = @inventoryNumber
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 25.12.2017 15:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
(
 @ids intTable READONLY,
 @id int,
 @name nvarchar(50),
 @passwrod nvarchar(max),
 @email nvarchar (255)
)
AS
BEGIN TRY 

BEGIN TRAN

    UPDATE Users SET
    Users.Name = @name, 
    Users.Password = @passwrod,
    Users.Email = @email
    WHERE Users.idUser = @id

	DELETE FROM UsersRoles
	WHERE UsersRoles.idUser = @id

	INSERT INTO dbo.UsersRoles
	SELECT @id, id FROM @ids

	COMMIT TRAN
END TRY

BEGIN CATCH
    ROLLBACK TRAN
END CATCH


GO
USE [master]
GO
ALTER DATABASE [AccountingBookDB] SET  READ_WRITE 
GO

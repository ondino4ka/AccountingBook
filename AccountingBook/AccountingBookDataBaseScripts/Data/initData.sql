USE [AccountingBookDB]
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
SET IDENTITY_INSERT [dbo].[Roles] ON 

GO
INSERT [dbo].[Roles] ([idRole], [Name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([idRole], [Name]) VALUES (2, N'Edit')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([idUser], [Name], [Password], [Email]) VALUES (1, N'kostya', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', N'kostik.cirotkin@yandex.ru')
GO
INSERT [dbo].[Users] ([idUser], [Name], [Password], [Email]) VALUES (2, N'maxim', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', N'maxim-dollar@yandex.ru')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UsersRoles] ([idUser], [idRole]) VALUES (1, 1)
GO
INSERT [dbo].[UsersRoles] ([idUser], [idRole]) VALUES (1, 2)
GO
INSERT [dbo].[UsersRoles] ([idUser], [idRole]) VALUES (2, 2)
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

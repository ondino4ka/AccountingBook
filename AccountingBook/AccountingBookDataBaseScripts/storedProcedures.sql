USE [AccountingBookDB]
GO
CREATE PROCEDURE [dbo].[SelectCategories]
AS
BEGIN
SELECT [idCategory],[Name]
FROM [dbo].[Categories]
END

GO
CREATE PROCEDURE [dbo].[SelectSubCategories]
AS
SELECT [idSubCategory],[Name],[idCategory]
FROM [dbo].[SubCategories]

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

USE [AccountingBookDB]
GO
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
SELECT Categories.idCategory,  isnull(dbo.GetCategoryNameById(pid), ' ') + ' - ' + Categories.Name
FROM Categories
WHERE Categories.Name LIKE ISNULL('%' + @categoryName +'%', '%')
END


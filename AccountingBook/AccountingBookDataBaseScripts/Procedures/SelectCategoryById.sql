USE [AccountingBookDB]
GO
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


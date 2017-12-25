USE [AccountingBookDB]
GO
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


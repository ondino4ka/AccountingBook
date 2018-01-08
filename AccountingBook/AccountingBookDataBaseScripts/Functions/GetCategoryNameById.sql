USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetCategoryNameById]
(
@id int
)
RETURNS nvarchar (50)
AS
BEGIN
	DECLARE @categoryName nvarchar(50)
	SET @categoryName = 
	(SELECT Categories.Name FROM Categories WHERE Categories.idCategory = @id)	
	RETURN @categoryName

END

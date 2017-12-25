USE [AccountingBookDB]
GO
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


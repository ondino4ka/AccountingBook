USE [AccountingBookDB]
GO
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

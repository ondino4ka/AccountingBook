USE [AccountingBookDB]
GO
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


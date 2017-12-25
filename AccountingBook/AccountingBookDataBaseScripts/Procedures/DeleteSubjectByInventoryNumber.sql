USE [AccountingBookDB]
GO
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


USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsExistSubject]
(
@inventoryNumber int
)
AS
BEGIN
IF EXISTS (SELECT Subjects.inventoryNumber FROM Subjects WHERE Subjects.inventoryNumber = @inventoryNumber)
RETURN 1
ELSE 
RETURN 0
END


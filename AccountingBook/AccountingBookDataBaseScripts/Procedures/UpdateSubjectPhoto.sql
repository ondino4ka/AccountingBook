USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSubjectPhoto]
(
@inventoryNumber int,
@photo nvarchar(256)
)
AS
BEGIN
    UPDATE Subjects SET
     Subjects.Photo = @photo
    WHERE Subjects.inventoryNumber = @inventoryNumber
END


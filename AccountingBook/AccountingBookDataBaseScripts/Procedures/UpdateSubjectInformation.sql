USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSubjectInformation]
(
 @inventoryNumber int,
 @name nvarchar(50),
 @stateId int = null,
 @categoryId int = null,
 @description nvarchar(max),
 @locationId int = null
)
AS
BEGIN 
    UPDATE Subjects SET
     Subjects.Name = @name,
	 Subjects.idState = @stateId,
	 Subjects.idCategory = @categoryId,
	 Subjects.Description = @description,
	 Subjects.idLocation = @locationId
    WHERE Subjects.inventoryNumber = @inventoryNumber
END



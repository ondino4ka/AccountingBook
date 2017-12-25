USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertSubject]
(
 @inventoryNumber int,
 @name nvarchar(50),
 @stateId int = null,
 @categoryId int = null,
 @photo nvarchar(256) = null,
 @description nvarchar(max),
 @locationId int = null
)
AS
BEGIN   
INSERT INTO Subjects
VALUES (@inventoryNumber, @name, @stateId, @categoryId, @photo, @description, @locationId)
END


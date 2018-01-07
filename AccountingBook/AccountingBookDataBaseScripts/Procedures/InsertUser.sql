USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUser]
(
 @ids intTable READONLY,
 @name nvarchar(50),
 @password nvarchar(max),
 @email nvarchar (255)
)
AS
BEGIN   
    DECLARE @lastId int
    INSERT into dbo.Users 
	VALUES (@name, @password, @email) 
	SET @lastId = (SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY])

	INSERT INTO dbo.UsersRoles
	SELECT @lastId, id FROM @ids

END


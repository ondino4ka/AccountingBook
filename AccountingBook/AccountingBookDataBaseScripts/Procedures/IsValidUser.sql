USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsValidUser]
(
@userName nvarchar (50),
@password nvarchar (max)
)
AS
BEGIN
IF EXISTS (SELECT Users.idUser FROM Users WHERE Users.Name = @userName and Users.Password = @password)
RETURN 1
ELSE 
RETURN 0
END


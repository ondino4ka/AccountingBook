USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IsExistsUser]
(
@userName nvarchar (50),
@userId int = 0
)
AS
BEGIN
IF EXISTS (SELECT Users.idUser FROM Users WHERE Users.Name = @userName AND Users.idUser <> @userId)
RETURN 1
ELSE 
RETURN 0
END


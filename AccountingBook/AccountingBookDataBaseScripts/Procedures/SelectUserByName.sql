USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectUserByName]
(
@userName nvarchar(50)
)

AS
BEGIN
SELECT Users.idUser, Users.Name, Users.Email
FROM Users
WHERE Users.name = @userName
END


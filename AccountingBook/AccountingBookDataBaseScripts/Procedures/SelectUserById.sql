USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectUserById]
(
@userId int
)
AS
BEGIN
SELECT *
FROM Users
WHERE Users.idUser = @userId
END


USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectUsersByName]
(
@userName nvarchar(50)= null
)
AS
BEGIN
SELECT *
FROM Users
WHERE Users.Name LIKE ISNULL('%' + @userName + '%', '%')
END


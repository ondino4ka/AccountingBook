USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectRolesIdByUserId]
(
@userId int
)
AS
BEGIN
SELECT UsersRoles.idRole 
FROM UsersRoles
WHERE UsersRoles.idUser = @userId
END


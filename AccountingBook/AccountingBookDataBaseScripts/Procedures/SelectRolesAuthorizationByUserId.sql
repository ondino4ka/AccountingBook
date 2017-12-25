USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectRolesAuthorizationByUserId]
(
@userId int
)
AS
BEGIN
SELECT Roles.Name
FROM UsersRoles INNER JOIN Roles ON UsersRoles.idRole = Roles.idRole
WHERE UsersRoles.idUser = @userId
END


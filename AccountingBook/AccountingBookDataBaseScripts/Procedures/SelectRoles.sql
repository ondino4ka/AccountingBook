USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectRoles]
AS
BEGIN
SELECT Roles.idRole, Roles.Name
FROM Roles
END


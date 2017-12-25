USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
(
 @ids intTable READONLY,
 @id int,
 @name nvarchar(50),
 @passwrod nvarchar(max),
 @email nvarchar (255)
)
AS
BEGIN TRY 

BEGIN TRAN

    UPDATE Users SET
    Users.Name = @name, 
    Users.Password = @passwrod,
    Users.Email = @email
    WHERE Users.idUser = @id

	DELETE FROM UsersRoles
	WHERE UsersRoles.idUser = @id

	INSERT INTO dbo.UsersRoles
	SELECT @id, id FROM @ids

	COMMIT TRAN
END TRY

BEGIN CATCH
    ROLLBACK TRAN
END CATCH



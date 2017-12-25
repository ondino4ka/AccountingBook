USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStateById]
(
@stateId int
)
AS
BEGIN
DELETE FROM States
WHERE States.idState = @stateId
END


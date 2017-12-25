USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStateById]
(
@stateId int
)
AS
BEGIN
SELECT States.idState, States.StateName
FROM States
WHERE States.idState = @stateId
END


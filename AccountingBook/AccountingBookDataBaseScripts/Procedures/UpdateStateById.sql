USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStateById]
(
@stateId int,
@stateName nvarchar(50)
)
AS
BEGIN
UPDATE States
SET StateName = @stateName
WHERE idState = @stateId
END


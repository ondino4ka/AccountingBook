USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStates]
AS
BEGIN
SELECT States.idState, States.StateName
FROM States
END


USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStates]
AS
BEGIN
SELECT [idState], [StateName]
FROM [States]
END

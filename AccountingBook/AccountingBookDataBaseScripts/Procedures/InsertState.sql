USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertState]
(
@stateName nvarchar(50)
)
AS
BEGIN
INSERT INTO States
VALUES (@stateName)
END


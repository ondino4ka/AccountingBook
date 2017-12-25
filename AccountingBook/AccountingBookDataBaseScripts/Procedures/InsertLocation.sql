USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertLocation]
(
@address nvarchar(100)
)
AS
BEGIN
INSERT INTO Locations
VALUES (@address)
END


USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCategory]
(
@pid int = null,
@categoryName nvarchar(50)
)
AS
BEGIN
INSERT INTO Categories 
VALUES (@pid, @categoryName)
END


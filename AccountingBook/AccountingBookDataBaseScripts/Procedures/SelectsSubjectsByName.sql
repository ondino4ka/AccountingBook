USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectsSubjectsByName]
(
@name nvarchar (50) = NULL
)
AS
BEGIN
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description 
FROM  Subjects 		 
WHERE dbo.Subjects.Name LIKE ISNULL('%' + @name + '%','%')
END


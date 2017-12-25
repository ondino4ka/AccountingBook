USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectSubjectInformationById]
(
@inventoryNumber int
)
AS
BEGIN
SELECT        dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.States.StateName, dbo.Categories.Name AS Expr1, dbo.Subjects.Photo, dbo.Subjects.Description, dbo.Locations.Address
FROM            dbo.Categories RIGHT JOIN
                         dbo.Subjects ON dbo.Categories.idCategory = dbo.Subjects.idCategory LEFT JOIN
                         dbo.States ON dbo.Subjects.idState = dbo.States.idState LEFT JOIN
                         dbo.Locations ON dbo.Subjects.idLocation = dbo.Locations.idLocation
WHERE dbo.Subjects.inventoryNumber = @inventoryNumber
END


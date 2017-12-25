USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectSubjectByNameCategoryIdAndStateId]
(
@subjectName nvarchar(50) = null,
@idState int = null,
@categoryId int = null
)
AS
BEGIN
if @categoryId is not null and @categoryId <> 0
BEGIN
with Recursion
as
(
select idCategory, pid, name
from Categories
where  idCategory = @categoryId
union all
select c.idCategory, c.pid,c.name
FROM Categories c INNER JOIN Recursion r ON c.pid = r.idCategory
)
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description, dbo.Subjects.idCategory
FROM  (SELECT r.idCategory
From Recursion r) r1 INNER JOIN Subjects ON r1.idCategory = Subjects.idCategory
WHERE Subjects.Name LIKE isnull('%' + @subjectName + '%', '%')
 and ((@idState = 0 and Subjects.idState <> @idState) or Subjects.idState = @idState or (Subjects.idState is null and @idState is null))
END
ELSE
BEGIN
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description, dbo.Subjects.idCategory
FROM  Subjects
WHERE Subjects.Name LIKE isnull('%' + @subjectName + '%', '%')
 and ((@idState = 0 and Subjects.idState <> @idState) or Subjects.idState = @idState or (Subjects.idState is null and @idState is null))
 and  ((@categoryId is null and Subjects.idCategory is null) or (@categoryId = 0 and Subjects.idCategory <> @categoryId))
END
END

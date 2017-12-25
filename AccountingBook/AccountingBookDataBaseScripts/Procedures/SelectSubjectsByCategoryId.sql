USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectSubjectsByCategoryId]
(
@categoryId int
)
AS
BEGIN
if @categoryId is not null
BEGIN
with Recursion
as
(
select idCategory, pid, name
from Categories
where  idCategory = @categoryId
union all
select c.idCategory, c.pid, c.name
FROM Categories c INNER JOIN Recursion r ON c.pid = r.idCategory
)
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description 
FROM  (SELECT r.idCategory
From Recursion r) r1 INNER JOIN Subjects ON r1.idCategory = Subjects.idCategory
END
ELSE
BEGIN
SELECT dbo.Subjects.inventoryNumber, dbo.Subjects.Name, dbo.Subjects.Photo, dbo.Subjects.Description 
FROM  Subjects
WHERE Subjects.idCategory IS NULL
END
end


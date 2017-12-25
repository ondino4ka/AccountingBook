USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[DeleteCategoryById]
(
@categoryId int
)
AS
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
delete from Categories
where idCategory in (select idCategory from Recursion)
end


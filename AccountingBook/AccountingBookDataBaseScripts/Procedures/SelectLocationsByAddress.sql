USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectLocationsByAddress]
(
@address nvarchar(100) = null
)

AS
BEGIN
SELECT Locations.idLocation, Locations.Address
FROM Locations
WHERE Locations.Address LIKE ISNULL('%' + @address + '%', '%')
END


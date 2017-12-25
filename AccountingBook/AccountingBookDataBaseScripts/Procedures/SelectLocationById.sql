USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectLocationById]
(
@idLocation int 
)

AS
BEGIN
SELECT Locations.idLocation, Locations.Address
FROM Locations
WHERE Locations.idLocation = @idLocation
END


USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteLocationById]
(
@locationId int
)
AS
BEGIN
DELETE FROM Locations
WHERE Locations.idLocation = @locationId
END


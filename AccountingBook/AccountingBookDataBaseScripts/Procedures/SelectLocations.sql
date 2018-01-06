USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectLocations]

AS
BEGIN
SELECT Locations.idLocation, Locations.Address
FROM Locations
END

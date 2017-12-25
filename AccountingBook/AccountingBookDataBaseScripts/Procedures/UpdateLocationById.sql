USE [AccountingBookDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLocationById]
(
@locationId int,
@address nvarchar(100)
)
AS
BEGIN
UPDATE Locations 
SET Address = @address
WHERE idLocation = @locationId
END


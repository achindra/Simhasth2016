CREATE PROCEDURE [dbo].[prc_GetNearByResources]
	@Lat float,
	@Long float,
	@radius float
AS
	select Name, Phone, BloodGroup, Hierarchy, Reserve1, Lat, Long, LastUpdated,
		dbo.Distance(@Lat, @Long, Lat, Long) AS Distance
	from [ResourceManager].[Resource]
	where dbo.Distance(@Lat, @Long, Lat, Long) <= @radius
	Order By Distance
RETURN 0

CREATE PROCEDURE [dbo].[prc_UpsertResource]
	@Name NVARCHAR(250),
	@Phone NVARCHAR(15),
	@BloodGroup NVARCHAR(10),
	@Hierarchy NVARCHAR(50),
	@Reserve1 NVARCHAR(50),
	@Lat float,
	@Long float
AS
	DECLARE @datetime Datetime = getutcdate();
	IF NOT EXISTS (SELECT 1 FROM [ResourceManager].[Resource] WHERE Phone = @Phone)
	BEGIN
		insert into [ResourceManager].[Resource]
		values (@Name, @Phone, @BloodGroup, @Hierarchy, @Reserve1, @Lat, @Long, @datetime)
	END
	else
	BEGIN
		update [ResourceManager].[Resource]
		set Name = @Name,
			Phone = @Phone,
			BloodGroup = @BloodGroup,
			Hierarchy = @Hierarchy,
			Reserve1 = @Reserve1,
			Lat = @Lat,
			Long = @Long,
			LastUpdated = @datetime
		where Phone = @Phone
	END
	select Name, Phone, BloodGroup, Hierarchy, Reserve1, Lat, Long, LastUpdated
	FROM [ResourceManager].[Resource] where LastUpdated = @datetime;
RETURN 0

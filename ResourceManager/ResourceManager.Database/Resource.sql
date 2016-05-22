CREATE TABLE [ResourceManager].[Resource]
(
	[Name] NVARCHAR(250) NOT NULL,
	[Phone] NVARCHAR(15) PRIMARY KEY,
	[BloodGroup] NVARCHAR(10) NOT NULL,
	[Hierarchy] NVARCHAR(50),
	[Reserve1] NVARCHAR(50),
	[Lat] float NOT NULL,
	[Long] float NOT NULL,
	[LastUpdated] Datetime NOT NULL
)

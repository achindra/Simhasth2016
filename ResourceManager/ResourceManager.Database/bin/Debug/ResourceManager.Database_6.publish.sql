﻿/*
Deployment script for ResourceManager

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ResourceManager"
:setvar DefaultFilePrefix "ResourceManager"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column BloodGroup on table [ResourceManager].[Resource] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column LastUpdated on table [ResourceManager].[Resource] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Lat on table [ResourceManager].[Resource] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Long on table [ResourceManager].[Resource] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [ResourceManager].[Resource])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering [ResourceManager].[Resource]...';


GO
ALTER TABLE [ResourceManager].[Resource] ALTER COLUMN [BloodGroup] NVARCHAR (10) NOT NULL;

ALTER TABLE [ResourceManager].[Resource] ALTER COLUMN [LastUpdated] DATETIME NOT NULL;

ALTER TABLE [ResourceManager].[Resource] ALTER COLUMN [Lat] FLOAT (53) NOT NULL;

ALTER TABLE [ResourceManager].[Resource] ALTER COLUMN [Long] FLOAT (53) NOT NULL;


GO
PRINT N'Refreshing [dbo].[prc_GetNearByResources]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[prc_GetNearByResources]';


GO
PRINT N'Refreshing [dbo].[prc_UpsertResource]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[prc_UpsertResource]';


GO
PRINT N'Update complete.';


GO

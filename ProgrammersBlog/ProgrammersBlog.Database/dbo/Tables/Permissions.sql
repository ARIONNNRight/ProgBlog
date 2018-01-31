CREATE TABLE [dbo].[Permissions]
(
	[PermissionId] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0
)

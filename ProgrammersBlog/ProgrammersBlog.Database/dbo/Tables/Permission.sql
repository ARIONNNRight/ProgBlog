CREATE TABLE [dbo].[Permission] (
    [PermissionId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [Deleted]      BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Permission] PRIMARY KEY CLUSTERED ([PermissionId] ASC)
);


CREATE TABLE [dbo].[Roles] (
    [RoleId]      INT IDENTITY (1, 1) NOT NULL,
    [RoleName]    NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(50) NOT NULL,
    [Deleted]     BIT NOT NULL,
    CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED ([RoleId] ASC)
);


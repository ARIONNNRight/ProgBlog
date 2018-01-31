CREATE TABLE [dbo].[Role_Permission] (
    [RoleId]       INT NOT NULL,
    [PermissionId] INT NOT NULL,
    CONSTRAINT [PK_dbo.Role_Permission] PRIMARY KEY CLUSTERED ([RoleId] ASC, [PermissionId] ASC),
    CONSTRAINT [FK_dbo.Role_Permission_dbo.Permission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([PermissionId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Role_Permission_dbo.Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[Role_Permission]([RoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PermissionId]
    ON [dbo].[Role_Permission]([PermissionId] ASC);


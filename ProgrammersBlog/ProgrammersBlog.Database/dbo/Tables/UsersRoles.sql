CREATE TABLE [dbo].[UsersRoles] (
    [RoleId]      INT NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT [PK_dbo.UsersRoles] PRIMARY KEY CLUSTERED ([RoleId] ASC, [UserId] ASC), 
    CONSTRAINT [FK_UsersRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([RoleId]), 
    CONSTRAINT [FK_UsersRoles_User] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
);


GO

CREATE TABLE [dbo].[User] (
    [UserId]    INT            IDENTITY (1, 1) NOT NULL,
    [UserName]  NVARCHAR (MAX) NULL,
    [Email]     NVARCHAR (MAX) NULL,
    [Password]  NVARCHAR (MAX) NULL,
    [BirthDay]  DATETIMEOFFSET       NOT NULL,
    [Avatar]    NVARCHAR (MAX) NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    [Inactive]  BIT            CONSTRAINT [DF_User_Inactive] DEFAULT 0 NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


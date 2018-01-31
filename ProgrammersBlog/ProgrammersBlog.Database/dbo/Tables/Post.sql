CREATE TABLE [dbo].[Post] (
    [PostId]      INT                IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (500)     NOT NULL,
    [Body]        NVARCHAR (MAX)     NOT NULL,
    [Deleted]     BIT                CONSTRAINT [DF_Post_Deleted] DEFAULT ((0)) NOT NULL,
    [CreatedDate] DATETIMEOFFSET (7) CONSTRAINT [DF_Post_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UserId]      INT                NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED ([PostId] ASC),
    CONSTRAINT [FK_Post_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);


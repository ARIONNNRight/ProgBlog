CREATE TABLE [dbo].[Comment] (
    [CommentId]   INT                IDENTITY (1, 1) NOT NULL,
    [Body]        NVARCHAR (MAX)     NOT NULL,
    [PostId]      INT                NOT NULL,
    [Deleted]     BIT                CONSTRAINT [DF_Comment_Deleted] DEFAULT ((0)) NOT NULL,
    [CreatedDate] DATETIMEOFFSET (7) CONSTRAINT [DF_Comment_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UserId]      INT                NOT NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([CommentId] ASC),
    CONSTRAINT [FK_Comment_Post] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Post] ([PostId]),
    CONSTRAINT [FK_Comment_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);


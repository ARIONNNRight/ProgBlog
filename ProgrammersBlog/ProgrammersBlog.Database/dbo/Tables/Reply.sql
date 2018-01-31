CREATE TABLE [dbo].[Reply] (
    [ReplyId]       INT                IDENTITY (1, 1) NOT NULL,
    [Body]          NVARCHAR (MAX)     NOT NULL,
    [Deleted]       BIT                CONSTRAINT [DF_Reply_Deleted] DEFAULT ((0)) NOT NULL,
    [ParentReplyId] INT                NULL,
    [CreatedDate]   DATETIMEOFFSET (7) CONSTRAINT [DF_Reply_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UserId]        INT                NOT NULL,
    [CommentId]     INT                NULL,
    CONSTRAINT [PK_Reply] PRIMARY KEY CLUSTERED ([ReplyId] ASC),
    CONSTRAINT [FK_Reply_Comment] FOREIGN KEY ([CommentId]) REFERENCES [dbo].[Comment] ([CommentId]),
    CONSTRAINT [FK_Reply_Reply] FOREIGN KEY ([ParentReplyId]) REFERENCES [dbo].[Reply] ([ReplyId]),
    CONSTRAINT [FK_Reply_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);


CREATE TABLE [dbo].[Comments] (
    [CommentId]    INT            IDENTITY (1, 1) NOT NULL,
    [BodyComments] NVARCHAR (MAX) NULL,
    [UserId]       INT            NOT NULL,
    [Deleted]      BIT            NOT NULL,
    [PostId]       INT            NOT NULL,
    CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED ([CommentId] ASC),
    CONSTRAINT [FK_dbo.Comments_dbo.Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Posts] ([PostId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PostId]
    ON [dbo].[Comments]([PostId] ASC);


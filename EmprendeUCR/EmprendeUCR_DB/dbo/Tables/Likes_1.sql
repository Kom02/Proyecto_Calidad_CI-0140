CREATE TABLE [dbo].[Likes] (
    [Members_Email] VARCHAR (100) NOT NULL,
    [Category_Id]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Members_Email] ASC, [Category_Id] ASC),
    CONSTRAINT [FK_Likes_Category] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[Category] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Likes_Email] FOREIGN KEY ([Members_Email]) REFERENCES [dbo].[Members] ([User_Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [ix_client_category]
    ON [dbo].[Likes]([Members_Email] ASC, [Category_Id] ASC);


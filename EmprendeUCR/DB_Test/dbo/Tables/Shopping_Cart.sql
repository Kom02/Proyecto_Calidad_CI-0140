CREATE TABLE [dbo].[Shopping_Cart] (
    [Email] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC),
    CONSTRAINT [FK_dbo.Shopping_Cart_dbo.Client] FOREIGN KEY ([Email]) REFERENCES [dbo].[Client] ([User_Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


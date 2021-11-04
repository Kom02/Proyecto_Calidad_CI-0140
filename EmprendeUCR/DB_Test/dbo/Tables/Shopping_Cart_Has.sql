CREATE TABLE [dbo].[Shopping_Cart_Has] (
    [Email]              VARCHAR (100) NOT NULL,
    [Code_ID]            INT           NOT NULL,
    [Entrepreneur_Email] VARCHAR (100) NOT NULL,
    [Category_ID]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC, [Code_ID] ASC, [Entrepreneur_Email] ASC, [Category_ID] ASC),
    CONSTRAINT [FK_dbo.Shopping_Cart_Has_dbo.Product_Service] FOREIGN KEY ([Code_ID], [Entrepreneur_Email], [Category_ID]) REFERENCES [dbo].[Product_Service] ([Code_ID], [Entrepreneur_Email], [Category_ID]),
    CONSTRAINT [FK_dbo.Shopping_Cart_Has_dbo.Shopping_Cart] FOREIGN KEY ([Email]) REFERENCES [dbo].[Shopping_Cart] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [emailSecondaryIndex]
    ON [dbo].[Shopping_Cart_Has]([Email] ASC);


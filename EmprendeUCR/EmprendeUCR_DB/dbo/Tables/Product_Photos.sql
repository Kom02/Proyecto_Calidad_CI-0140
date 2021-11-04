CREATE TABLE [dbo].[Product_Photos] (
    [Product_Photos_ID]  INT             IDENTITY (1, 1) NOT NULL,
    [Code_ID]            INT             NOT NULL,
    [Photos]             VARBINARY (MAX) NULL,
    [Entrepreneur_Email] VARCHAR (100)   NOT NULL,
    [Category_ID]        INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Product_Photos_ID] ASC, [Code_ID] ASC, [Entrepreneur_Email] ASC, [Category_ID] ASC),
    FOREIGN KEY ([Code_ID], [Entrepreneur_Email], [Category_ID]) REFERENCES [dbo].[Product] ([Code_ID], [Entrepreneur_Email], [Category_ID]) ON DELETE CASCADE ON UPDATE CASCADE
);


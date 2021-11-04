CREATE TABLE [dbo].[HasSupplies] (
    [Code_ID]            INT           NOT NULL,
    [Entrepreneur_Email] VARCHAR (100) NOT NULL,
    [Category_ID]        INT           NOT NULL,
    [Supplie_ID]         INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Code_ID] ASC, [Entrepreneur_Email] ASC, [Category_ID] ASC, [Supplie_ID] ASC),
    FOREIGN KEY ([Supplie_ID]) REFERENCES [dbo].[Category] ([Id]),
    FOREIGN KEY ([Code_ID], [Entrepreneur_Email], [Category_ID]) REFERENCES [dbo].[Product_Service] ([Code_ID], [Entrepreneur_Email], [Category_ID]) ON DELETE CASCADE ON UPDATE CASCADE
);


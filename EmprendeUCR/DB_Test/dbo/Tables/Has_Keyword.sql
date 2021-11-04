CREATE TABLE [dbo].[Has_Keyword] (
    [Product_ID]                 INT           NOT NULL,
    [Product_Entrepreneur_Email] VARCHAR (100) NOT NULL,
    [Product_Category_ID]        INT           NOT NULL,
    [Keyword_ID]                 INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Keyword_ID] ASC, [Product_ID] ASC, [Product_Entrepreneur_Email] ASC, [Product_Category_ID] ASC),
    FOREIGN KEY ([Keyword_ID]) REFERENCES [dbo].[Keyword] ([Id]),
    FOREIGN KEY ([Product_ID], [Product_Entrepreneur_Email], [Product_Category_ID]) REFERENCES [dbo].[Product] ([Code_ID], [Entrepreneur_Email], [Category_ID])
);


CREATE TABLE [dbo].[Has_Status] (
    [Name]               VARCHAR (30)  NOT NULL,
    [Code_ID]            INT           NOT NULL,
    [Entrepreneur_Email] VARCHAR (100) NOT NULL,
    [Category_ID]        INT           NOT NULL,
    [Order]              INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Name] ASC, [Code_ID] ASC, [Entrepreneur_Email] ASC, [Category_ID] ASC),
    CONSTRAINT [FK_dbo.Has_Status_dbo.Personalized_Status] FOREIGN KEY ([Name]) REFERENCES [dbo].[Status] ([Name]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_dbo.Has_Status_dbo.Product_Service] FOREIGN KEY ([Code_ID], [Entrepreneur_Email], [Category_ID]) REFERENCES [dbo].[Product_Service] ([Code_ID], [Entrepreneur_Email], [Category_ID])
);


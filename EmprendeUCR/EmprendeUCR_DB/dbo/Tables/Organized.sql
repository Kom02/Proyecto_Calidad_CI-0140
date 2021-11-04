CREATE TABLE [dbo].[Organized] (
    [Code_ID]                   INT           NOT NULL,
    [Entrepreneur_Email]        VARCHAR (100) NOT NULL,
    [Category_ID]               INT           NOT NULL,
    [Date_and_hour_of_creation] DATETIME      NOT NULL,
    [Email]                     VARCHAR (100) NOT NULL,
    [Name]                      VARCHAR (30)  NOT NULL,
    [Quantity]                  INT           NOT NULL,
    [Date_of_Change]            DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Code_ID] ASC, [Entrepreneur_Email] ASC, [Category_ID] ASC, [Date_and_hour_of_creation] ASC, [Email] ASC, [Name] ASC),
    CONSTRAINT [FK_dbo.Organized_dbo.Order] FOREIGN KEY ([Date_and_hour_of_creation], [Email]) REFERENCES [dbo].[Order] ([Date_and_hour_of_creation], [Client_Email]),
    CONSTRAINT [FK_dbo.Organized_dbo.Product_Service] FOREIGN KEY ([Code_ID], [Entrepreneur_Email], [Category_ID]) REFERENCES [dbo].[Product_Service] ([Code_ID], [Entrepreneur_Email], [Category_ID]) ON UPDATE CASCADE,
    CONSTRAINT [FK_dbo.Organized_dbo.Status] FOREIGN KEY ([Name]) REFERENCES [dbo].[Status] ([Name]) ON UPDATE CASCADE
);




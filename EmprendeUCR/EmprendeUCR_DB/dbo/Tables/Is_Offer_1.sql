CREATE TABLE [dbo].[Is_Offer] (
    [Offer_ID]    INT           NOT NULL,
    [Code_ID]     INT           NOT NULL,
    [User_Email]  VARCHAR (100) NOT NULL,
    [Category_ID] INT           NOT NULL,
    [Amount]      INT           DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([Offer_ID] ASC, [Code_ID] ASC, [User_Email] ASC, [Category_ID] ASC),
    FOREIGN KEY ([Offer_ID]) REFERENCES [dbo].[Offer] ([Offer_ID]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([Code_ID], [User_Email], [Category_ID]) REFERENCES [dbo].[Product_Service] ([Code_ID], [Entrepreneur_Email], [Category_ID]) ON DELETE CASCADE ON UPDATE CASCADE
);


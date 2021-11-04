CREATE TABLE [dbo].[Offer] (
    [Offer_ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Initial_Date]      DATE          NOT NULL,
    [Expire_Date]       DATE          NOT NULL,
    [Offer_Description] VARCHAR (220) NULL,
    [Discount]          INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Offer_ID] ASC)
);


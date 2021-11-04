CREATE TABLE [dbo].[PaymentMethod] (
    [Name]   VARCHAR (30) NOT NULL,
    [Status] BIT          NOT NULL,
    [Type]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Name] ASC),
    CHECK ([Type]>=(0) AND [Type]<=(2))
);


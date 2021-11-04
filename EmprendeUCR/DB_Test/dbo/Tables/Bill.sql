CREATE TABLE [dbo].[Bill] (
    [Date_and_hour_of_creation] DATETIME      NOT NULL,
    [Client_Email]              VARCHAR (100) NOT NULL,
    [Number_of_bill]            INT           NOT NULL,
    [Date_of_Creation]          DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Date_and_hour_of_creation] ASC, [Client_Email] ASC, [Number_of_bill] ASC),
    CONSTRAINT [FK_dbo.Bill_dbo.Order] FOREIGN KEY ([Date_and_hour_of_creation], [Client_Email]) REFERENCES [dbo].[Order] ([Date_and_hour_of_creation], [Client_Email])
);


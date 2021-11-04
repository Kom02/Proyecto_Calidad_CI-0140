CREATE TABLE [dbo].[SinpePaymentMethod] (
    [Phone_Number]       INT           NOT NULL,
    [Entrepreneur_Email] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Phone_Number] ASC, [Entrepreneur_Email] ASC),
    FOREIGN KEY ([Entrepreneur_Email]) REFERENCES [dbo].[Entrepreneur] ([User_Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


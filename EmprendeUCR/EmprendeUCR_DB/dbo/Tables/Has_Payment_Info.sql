CREATE TABLE [dbo].[Has_Payment_Info] (
    [Entrepreneur_Email] VARCHAR (100) NOT NULL,
    [Payment_Info_ID]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Entrepreneur_Email] ASC, [Payment_Info_ID] ASC),
    FOREIGN KEY ([Entrepreneur_Email]) REFERENCES [dbo].[Entrepreneur] ([User_Email]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([Payment_Info_ID]) REFERENCES [dbo].[Payment_Info] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);


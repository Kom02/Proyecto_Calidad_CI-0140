CREATE TABLE [dbo].[Utilizes_Chat] (
    [User_Email] VARCHAR (100) NOT NULL,
    [Chat_ID]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Chat_ID] ASC, [User_Email] ASC),
    FOREIGN KEY ([Chat_ID]) REFERENCES [dbo].[Chat] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([User_Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


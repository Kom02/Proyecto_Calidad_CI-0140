CREATE TABLE [dbo].[Message] (
    [Chat_ID]           INT                NOT NULL,
    [Message_Date]      DATETIMEOFFSET (7) NOT NULL,
    [Writer_User_Email] VARCHAR (100)      NOT NULL,
    [Reader_User_Email] VARCHAR (100)      NOT NULL,
    [Content]           VARCHAR (3500)     NOT NULL,
    [Seen]              INT                DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Chat_ID] ASC, [Message_Date] ASC),
    FOREIGN KEY ([Chat_ID]) REFERENCES [dbo].[Chat] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([Reader_User_Email]) REFERENCES [dbo].[User] ([Email]),
    FOREIGN KEY ([Writer_User_Email]) REFERENCES [dbo].[User] ([Email])
);


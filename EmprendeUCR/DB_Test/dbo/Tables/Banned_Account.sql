CREATE TABLE [dbo].[Banned_Account] (
    [UserEmail]  VARCHAR (100) NOT NULL,
    [BeginDate]  DATE          NULL,
    [FinishDate] DATE          NULL,
    [Type]       BIT           NULL,
    PRIMARY KEY CLUSTERED ([UserEmail] ASC),
    FOREIGN KEY ([UserEmail]) REFERENCES [dbo].[Members] ([User_Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


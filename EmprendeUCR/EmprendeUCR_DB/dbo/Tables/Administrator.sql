CREATE TABLE [dbo].[Administrator] (
    [User_Email] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([User_Email] ASC),
    CONSTRAINT [FK_User] FOREIGN KEY ([User_Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


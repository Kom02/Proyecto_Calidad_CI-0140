CREATE TABLE [dbo].[Phones] (
    [User_Email]   VARCHAR (100) NOT NULL,
    [Phone_Number] VARCHAR (8)   NOT NULL,
    PRIMARY KEY CLUSTERED ([User_Email] ASC),
    CONSTRAINT [FK_Phones_User] FOREIGN KEY ([User_Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE TABLE [dbo].[Credentials] (
    [User_Email] VARCHAR (100) NOT NULL,
    [Password]   VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([User_Email] ASC),
    CONSTRAINT [FK_Credentials_User] FOREIGN KEY ([User_Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


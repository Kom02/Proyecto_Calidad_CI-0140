CREATE TABLE [dbo].[Client] (
    [User_Email] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([User_Email] ASC),
    CONSTRAINT [FK_Client_Members] FOREIGN KEY ([User_Email]) REFERENCES [dbo].[Members] ([User_Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE TABLE [dbo].[Members] (
    [User_Email] VARCHAR (100) NOT NULL,
    [Score]      INT           NULL,
    [Lat]        FLOAT (53)    NULL,
    [Long]       FLOAT (53)    NULL,
    [Direction]  VARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([User_Email] ASC),
    CONSTRAINT [FK_Members_User] FOREIGN KEY ([User_Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IDX_Members]
    ON [dbo].[Members]([User_Email] ASC, [Score] ASC, [Lat] ASC, [Long] ASC, [Direction] ASC);


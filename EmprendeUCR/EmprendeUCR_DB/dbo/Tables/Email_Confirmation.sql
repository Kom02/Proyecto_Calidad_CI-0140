CREATE TABLE [dbo].[Email_Confirmation] (
    [Email]           VARCHAR (100) NOT NULL,
    [Hash_Code]       VARCHAR (250) NULL,
    [Creation_Date]   DATE          NULL,
    [Expiration_Date] DATE          NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC),
    CONSTRAINT [FK_Email] FOREIGN KEY ([Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [index_Email]
    ON [dbo].[Email_Confirmation]([Email] ASC, [Hash_Code] ASC, [Creation_Date] ASC, [Expiration_Date] ASC);


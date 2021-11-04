CREATE TABLE [dbo].[ActiveAdministrators] (
    [Email]         VARCHAR (100) NOT NULL,
    [Creation_Date] DATE          NULL,
    [Response]      BIT           NULL,
    [Confirm]       BIT           NULL,
    [Active]        BIT           NULL,
    [Response_Date] DATE          NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC),
    CONSTRAINT [FK_UserAdmin] FOREIGN KEY ([Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


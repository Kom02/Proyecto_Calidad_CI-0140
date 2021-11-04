CREATE TABLE [dbo].[Personalized_Status] (
    [Name] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Name] ASC),
    CONSTRAINT [FK_dbo.Personalized_Status_dbo.Status] FOREIGN KEY ([Name]) REFERENCES [dbo].[Status] ([Name]) ON DELETE CASCADE ON UPDATE CASCADE
);


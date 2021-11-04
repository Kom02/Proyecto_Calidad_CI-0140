CREATE TABLE [dbo].[Category] (
    [Title]       VARCHAR (30) NOT NULL,
    [Description] VARCHAR (50) NULL,
    [TitleDad]    VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Title] ASC),
    FOREIGN KEY ([TitleDad]) REFERENCES [dbo].[Category] ([Title])
);


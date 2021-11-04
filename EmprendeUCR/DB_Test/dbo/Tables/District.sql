CREATE TABLE [dbo].[District] (
    [Name]          VARCHAR (15) NOT NULL,
    [Province_Name] VARCHAR (15) NOT NULL,
    [Canton_Name]   VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([Name] ASC, [Province_Name] ASC, [Canton_Name] ASC),
    CONSTRAINT [FK_District_Canton] FOREIGN KEY ([Province_Name], [Canton_Name]) REFERENCES [dbo].[Canton] ([Province_Name], [Name]) ON DELETE CASCADE ON UPDATE CASCADE
);


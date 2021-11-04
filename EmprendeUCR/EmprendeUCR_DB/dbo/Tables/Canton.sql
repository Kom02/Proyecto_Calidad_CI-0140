CREATE TABLE [dbo].[Canton] (
    [Name]          VARCHAR (15) NOT NULL,
    [Province_Name] VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([Province_Name] ASC, [Name] ASC),
    CONSTRAINT [FK_Canton_Province] FOREIGN KEY ([Province_Name]) REFERENCES [dbo].[Province] ([Name]) ON DELETE CASCADE ON UPDATE CASCADE
);


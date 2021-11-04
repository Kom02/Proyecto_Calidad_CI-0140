CREATE TABLE [dbo].[Category] (
    [Title]       VARCHAR (30) NOT NULL,
    [Description] VARCHAR (50) NULL,
    [ParentId]    INT          NULL,
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Category] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [ix_category_title]
    ON [dbo].[Category]([Title] ASC, [ParentId] ASC, [Description] ASC);


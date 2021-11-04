CREATE TABLE [dbo].[Permission] (
    [Id]          INT           NOT NULL,
    [Role_Id]     INT           NOT NULL,
    [Description] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC, [Role_Id] ASC),
    CONSTRAINT [FK_Permission_Role] FOREIGN KEY ([Role_Id]) REFERENCES [dbo].[Role] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);


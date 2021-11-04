CREATE TABLE [dbo].[Is_Able_To] (
    [Email]         VARCHAR (100) NOT NULL,
    [Permission_Id] INT           NOT NULL,
    [Role_Id]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC, [Role_Id] ASC, [Permission_Id] ASC),
    CONSTRAINT [FK_Is_Able_To_Email] FOREIGN KEY ([Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Is_Able_To_Role_Permission] FOREIGN KEY ([Permission_Id], [Role_Id]) REFERENCES [dbo].[Permission] ([Id], [Role_Id]) ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE TABLE [dbo].[Status] (
    [Name]                VARCHAR (30) NOT NULL,
    [Previous_State_Name] VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Name] ASC),
    CONSTRAINT [FK_dbo.Status_dbo.Status] FOREIGN KEY ([Previous_State_Name]) REFERENCES [dbo].[Status] ([Name])
);


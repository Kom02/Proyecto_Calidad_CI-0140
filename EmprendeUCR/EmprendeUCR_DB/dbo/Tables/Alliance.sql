CREATE TABLE [dbo].[Alliance] (
    [Alliance_Id]     INT           IDENTITY (1, 1) NOT NULL,
    [User_Email]      VARCHAR (100) NOT NULL,
    [Ally_User_Email] VARCHAR (100) NOT NULL,
    [Alliance_Status] INT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Alliance_Id] ASC),
    FOREIGN KEY ([User_Email]) REFERENCES [dbo].[Entrepreneur] ([User_Email])
);




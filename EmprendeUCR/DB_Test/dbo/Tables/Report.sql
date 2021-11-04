CREATE TABLE [dbo].[Report] (
    [ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]   VARCHAR (100)  NOT NULL,
    [Content] VARCHAR (5000) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


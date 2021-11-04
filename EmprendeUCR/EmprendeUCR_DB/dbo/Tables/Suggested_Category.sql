CREATE TABLE [dbo].[Suggested_Category] (
    [ID]          INT          IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (30) NOT NULL,
    [Description] VARCHAR (50) NULL,
    [ParentID]    INT          NULL,
    [Status]      INT          DEFAULT ('0') NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


CREATE TABLE [dbo].[Has_Keyword_Service] (
    [Service_ID]                 INT           NOT NULL,
    [Service_Entrepreneur_Email] VARCHAR (100) NOT NULL,
    [Service_Category_ID]        INT           NOT NULL,
    [Keyword_ID]                 INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Keyword_ID] ASC, [Service_ID] ASC, [Service_Entrepreneur_Email] ASC, [Service_Category_ID] ASC),
    FOREIGN KEY ([Keyword_ID]) REFERENCES [dbo].[Keyword] ([Id]),
    FOREIGN KEY ([Service_ID], [Service_Entrepreneur_Email], [Service_Category_ID]) REFERENCES [dbo].[Service] ([Code_ID], [Entrepreneur_Email], [Category_ID])
);


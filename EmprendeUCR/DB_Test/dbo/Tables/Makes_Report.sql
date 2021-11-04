CREATE TABLE [dbo].[Makes_Report] (
    [Report_ID]  INT           NOT NULL,
    [User_Email] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Report_ID] ASC, [User_Email] ASC),
    CONSTRAINT [FK_ReportID] FOREIGN KEY ([Report_ID]) REFERENCES [dbo].[Report] ([ID]),
    CONSTRAINT [FK_User_Email] FOREIGN KEY ([User_Email]) REFERENCES [dbo].[User] ([Email])
);


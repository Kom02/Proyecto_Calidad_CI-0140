CREATE TABLE [dbo].[Service] (
    [Code_ID]             INT           NOT NULL,
    [Entrepreneur_Email]  VARCHAR (100) NOT NULL,
    [Category_ID]         INT           NOT NULL,
    [Service_Name]        VARCHAR (100) NOT NULL,
    [Service_Description] VARCHAR (220) NULL,
    [Price_per_hour]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Code_ID] ASC, [Entrepreneur_Email] ASC, [Category_ID] ASC),
    FOREIGN KEY ([Code_ID], [Entrepreneur_Email], [Category_ID]) REFERENCES [dbo].[Product_Service] ([Code_ID], [Entrepreneur_Email], [Category_ID]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [ix_service_category]
    ON [dbo].[Service]([Category_ID] ASC);


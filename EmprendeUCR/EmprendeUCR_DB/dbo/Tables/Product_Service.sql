CREATE TABLE [dbo].[Product_Service] (
    [Code_ID]            INT           IDENTITY (1, 1) NOT NULL,
    [Entrepreneur_Email] VARCHAR (100) NOT NULL,
    [Availability]       TINYINT       DEFAULT ((1)) NOT NULL,
    [Category_ID]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Code_ID] ASC, [Entrepreneur_Email] ASC, [Category_ID] ASC),
    FOREIGN KEY ([Category_ID]) REFERENCES [dbo].[Category] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY ([Entrepreneur_Email]) REFERENCES [dbo].[Entrepreneur] ([User_Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [ix_product_services_by_availability]
    ON [dbo].[Product_Service]([Availability] ASC) WHERE ([Availability]>(0));


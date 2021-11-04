CREATE TABLE [dbo].[Electronic_Bill] (
    [Date_and_hour_of_creation] DATETIME        NOT NULL,
    [Email]                     VARCHAR (100)   NOT NULL,
    [Number_of_bill]            INT             NOT NULL,
    [ID]                        INT             NOT NULL,
    [Client_Email]              VARCHAR (100)   NOT NULL,
    [DNI_Client]                CHAR (10)       NOT NULL,
    [XML_Document]              VARBINARY (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Date_and_hour_of_creation] ASC, [Email] ASC, [Number_of_bill] ASC, [ID] ASC),
    CONSTRAINT [FK_dbo.Electronic_Bill_dbo.Bill] FOREIGN KEY ([Date_and_hour_of_creation], [Email], [Number_of_bill]) REFERENCES [dbo].[Bill] ([Date_and_hour_of_creation], [Client_Email], [Number_of_bill])
);


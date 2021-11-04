CREATE TABLE [dbo].[SINPE_IBAN_PI] (
    [Account_Number]      VARCHAR (22) NOT NULL,
    [Name_Payment_Method] VARCHAR (30) NOT NULL,
    [Payment_Info_ID]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Account_Number] ASC),
    FOREIGN KEY ([Name_Payment_Method]) REFERENCES [dbo].[SINPE_IBAN_PM] ([Name]) ON DELETE CASCADE,
    FOREIGN KEY ([Payment_Info_ID]) REFERENCES [dbo].[Payment_Info] ([ID]) ON DELETE CASCADE
);


CREATE TABLE [dbo].[SINPE_Movil_PI] (
    [Phone_Number]        INT          NOT NULL,
    [Name_Payment_Method] VARCHAR (30) NOT NULL,
    [Payment_Info_ID]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Phone_Number] ASC),
    CHECK ([Phone_Number]>=(0) AND [Phone_Number]<=(99999999)),
    FOREIGN KEY ([Name_Payment_Method]) REFERENCES [dbo].[SINPE_Movil_PM] ([Name]) ON DELETE CASCADE,
    FOREIGN KEY ([Payment_Info_ID]) REFERENCES [dbo].[Payment_Info] ([ID]) ON DELETE CASCADE
);


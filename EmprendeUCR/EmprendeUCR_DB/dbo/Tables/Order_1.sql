CREATE TABLE [dbo].[Order] (
    [Date_and_hour_of_creation]      DATETIME      NOT NULL,
    [Client_Email]                   VARCHAR (100) NOT NULL,
    [Details]                        VARCHAR (500) NULL,
    [Delivery_date]                  DATE          NOT NULL,
    [Delivery_Address]               VARCHAR (300) NULL,
    [Entrepreneur_Email]             VARCHAR (100) NOT NULL,
    [State]                          VARCHAR (30)  NOT NULL,
    [Payment_Name]                   VARCHAR (30)  NULL,
    [Date_and_hour_of_State_Changed] DATETIME      DEFAULT (sysdatetime()) NULL,
    [View]                           BIT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Date_and_hour_of_creation] ASC, [Client_Email] ASC),
    CONSTRAINT [FK_dbo.Order_dbo.Client] FOREIGN KEY ([Client_Email]) REFERENCES [dbo].[Client] ([User_Email]) ON UPDATE CASCADE,
    CONSTRAINT [FK_dbo.Order_dbo.Entrepreneur] FOREIGN KEY ([Entrepreneur_Email]) REFERENCES [dbo].[Entrepreneur] ([User_Email]),
    CONSTRAINT [FK_dbo.Order_dbo.Generic_Status] FOREIGN KEY ([State]) REFERENCES [dbo].[Generic_Status] ([Name])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [index_order_client_state]
    ON [dbo].[Order]([Date_and_hour_of_creation] ASC, [Client_Email] ASC)
    INCLUDE([Entrepreneur_Email], [State]);


GO
CREATE TRIGGER TR_UpdateDateAndHourWhenStateChange
	ON [Order] AFTER UPDATE
AS
BEGIN
	set nocount on
	declare @DateHourCreation datetime, @Email varchar(100)
	select @DateHourCreation = Date_and_hour_of_creation, @Email = Client_Email
	from inserted

	IF (UPDATE ([State]))
	BEGIN
		UPDATE [Order]
		SET Date_and_hour_of_State_Changed = GETDATE()
		WHERE Date_and_hour_of_creation = @DateHourCreation AND
			  Client_Email = @Email
	END;

END;
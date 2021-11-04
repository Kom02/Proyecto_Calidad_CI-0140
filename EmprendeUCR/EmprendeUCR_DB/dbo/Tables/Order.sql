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
    CHECK ([Delivery_date]>=CONVERT([date],getdate())),
    CONSTRAINT [FK_dbo.Order_dbo.Client] FOREIGN KEY ([Client_Email]) REFERENCES [dbo].[Client] ([User_Email]) ON UPDATE CASCADE,
    CONSTRAINT [FK_dbo.Order_dbo.Entrepreneur] FOREIGN KEY ([Entrepreneur_Email]) REFERENCES [dbo].[Entrepreneur] ([User_Email]),
    CONSTRAINT [FK_dbo.Order_dbo.Generic_Status] FOREIGN KEY ([State]) REFERENCES [dbo].[Generic_Status] ([Name])
);
















<<<<<<< HEAD
=======




>>>>>>> Develop
GO
CREATE NONCLUSTERED INDEX [indiceHJ]
    ON [dbo].[Order]([State] ASC, [Entrepreneur_Email] ASC, [Delivery_date] ASC, [Details] ASC);


GO

GO
CREATE UNIQUE NONCLUSTERED INDEX [index_order_client_state]
    ON [dbo].[Order]([Date_and_hour_of_creation] ASC, [Client_Email] ASC)
    INCLUDE([Entrepreneur_Email], [State]);


GO

GO

GO

GO

GO

GO

GO

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
GO
<<<<<<< HEAD
CREATE TRIGGER [tr_dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Sender] ON [dbo].[Order] 
=======
CREATE TRIGGER [tr_dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Sender] ON [dbo].[Order] 
>>>>>>> Develop
WITH EXECUTE AS SELF
AFTER insert, update, delete AS 
BEGIN
    SET NOCOUNT ON;

    DECLARE @rowsToProcess INT
    DECLARE @currentRow INT
    DECLARE @records XML
    DECLARE @theMessageContainer NVARCHAR(MAX)
    DECLARE @dmlType NVARCHAR(10)
<<<<<<< HEAD
    DECLARE @modifiedRecordsTable TABLE ([RowNumber] INT IDENTITY(1, 1), [State] varchar(30), [Entrepreneur_Email] varchar(100))
    DECLARE @exceptTable TABLE ([RowNumber] INT, [State] varchar(30), [Entrepreneur_Email] varchar(100))
	DECLARE @deletedTable TABLE ([RowNumber] INT IDENTITY(1, 1), [State] varchar(30), [Entrepreneur_Email] varchar(100))
    DECLARE @insertedTable TABLE ([RowNumber] INT IDENTITY(1, 1), [State] varchar(30), [Entrepreneur_Email] varchar(100))
    DECLARE @var1 varchar(30)
    DECLARE @var2 varchar(100)

    DECLARE @conversationHandlerExists INT
    SELECT @conversationHandlerExists = COUNT(*) FROM sys.conversation_endpoints WHERE conversation_handle = '2195a93b-74ea-eb11-b46b-d7085749938a';
=======
    DECLARE @modifiedRecordsTable TABLE ([RowNumber] INT IDENTITY(1, 1), [Client_Email] varchar(100), [State] varchar(30), [View] bit)
    DECLARE @exceptTable TABLE ([RowNumber] INT, [Client_Email] varchar(100), [State] varchar(30), [View] bit)
	DECLARE @deletedTable TABLE ([RowNumber] INT IDENTITY(1, 1), [Client_Email] varchar(100), [State] varchar(30), [View] bit)
    DECLARE @insertedTable TABLE ([RowNumber] INT IDENTITY(1, 1), [Client_Email] varchar(100), [State] varchar(30), [View] bit)
    DECLARE @var1 varchar(100)
    DECLARE @var2 varchar(30)
    DECLARE @var3 bit

    DECLARE @conversationHandlerExists INT
    SELECT @conversationHandlerExists = COUNT(*) FROM sys.conversation_endpoints WHERE conversation_handle = 'eba679eb-4ceb-eb11-b46b-d7085749938a';
>>>>>>> Develop
    IF @conversationHandlerExists = 0
    BEGIN
        DECLARE @conversation_handle UNIQUEIDENTIFIER;
        DECLARE @schema_id INT;
        SELECT @schema_id = schema_id FROM sys.schemas WITH (NOLOCK) WHERE name = N'dbo';

        
<<<<<<< HEAD
        IF EXISTS (SELECT * FROM sys.triggers WITH (NOLOCK) WHERE object_id = OBJECT_ID(N'[dbo].[tr_dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Sender]')) DROP TRIGGER [dbo].[tr_dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Sender') EXEC (N'ALTER QUEUE [dbo].[dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Sender] WITH ACTIVATION (STATUS = OFF)');

        
        SELECT conversation_handle INTO #Conversations FROM sys.conversation_endpoints WITH (NOLOCK) WHERE far_service LIKE N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_%' ORDER BY is_initiator ASC;
=======
        IF EXISTS (SELECT * FROM sys.triggers WITH (NOLOCK) WHERE object_id = OBJECT_ID(N'[dbo].[tr_dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Sender]')) DROP TRIGGER [dbo].[tr_dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Sender') EXEC (N'ALTER QUEUE [dbo].[dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Sender] WITH ACTIVATION (STATUS = OFF)');

        
        SELECT conversation_handle INTO #Conversations FROM sys.conversation_endpoints WITH (NOLOCK) WHERE far_service LIKE N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_%' ORDER BY is_initiator ASC;
>>>>>>> Develop
        DECLARE conversation_cursor CURSOR FAST_FORWARD FOR SELECT conversation_handle FROM #Conversations;
        OPEN conversation_cursor;
        FETCH NEXT FROM conversation_cursor INTO @conversation_handle;
        WHILE @@FETCH_STATUS = 0 
        BEGIN
            END CONVERSATION @conversation_handle WITH CLEANUP;
            FETCH NEXT FROM conversation_cursor INTO @conversation_handle;
        END
        CLOSE conversation_cursor;
        DEALLOCATE conversation_cursor;
        DROP TABLE #Conversations;

        
<<<<<<< HEAD
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Receiver') DROP SERVICE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Receiver];
        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Sender') DROP SERVICE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Receiver') DROP QUEUE [dbo].[dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Receiver];
        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Sender') DROP QUEUE [dbo].[dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_contracts WITH (NOLOCK) WHERE name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070') DROP CONTRACT [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070];
        
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/StartMessage/Insert') DROP MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/StartMessage/Insert];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/StartMessage/Update') DROP MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/StartMessage/Update];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/StartMessage/Delete') DROP MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/StartMessage/Delete];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/State') DROP MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/State];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/Entrepreneur_Email') DROP MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/Entrepreneur_Email];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/EndMessage') DROP MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/EndMessage];

        
        IF EXISTS (SELECT * FROM sys.objects WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_QueueActivationSender') DROP PROCEDURE [dbo].[dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070_QueueActivationSender];
=======
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Receiver') DROP SERVICE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Receiver];
        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Sender') DROP SERVICE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Receiver') DROP QUEUE [dbo].[dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Receiver];
        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Sender') DROP QUEUE [dbo].[dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_contracts WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97') DROP CONTRACT [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97];
        
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/StartMessage/Insert') DROP MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/StartMessage/Insert];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/StartMessage/Update') DROP MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/StartMessage/Update];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/StartMessage/Delete') DROP MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/StartMessage/Delete];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/Client_Email') DROP MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/Client_Email];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/State') DROP MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/State];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/View') DROP MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/View];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/EndMessage') DROP MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/EndMessage];

        
        IF EXISTS (SELECT * FROM sys.objects WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_QueueActivationSender') DROP PROCEDURE [dbo].[dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97_QueueActivationSender];
>>>>>>> Develop
        RETURN
    END
    
    IF NOT EXISTS(SELECT 1 FROM INSERTED)
    BEGIN
        SET @dmlType = 'Delete'
<<<<<<< HEAD
        INSERT INTO @modifiedRecordsTable SELECT [State], [Entrepreneur_Email] FROM DELETED WHERE (((([State] = 'Pendiente de revision') OR ([State] = 'Aceptado')) OR ([State] = 'Rechazado')) AND ([Entrepreneur_Email] = 'saguilar1999@hotmail.com'))
=======
        INSERT INTO @modifiedRecordsTable SELECT [Client_Email], [State], [View] FROM DELETED WHERE ((([State] = 'Aceptado') OR ([State] = 'Rechazado')) AND ([Client_Email] = 'soru1097@gmail.com'))
>>>>>>> Develop
    END
    ELSE
    BEGIN
        IF NOT EXISTS(SELECT * FROM DELETED)
        BEGIN
            SET @dmlType = 'Insert'
<<<<<<< HEAD
            INSERT INTO @modifiedRecordsTable SELECT [State], [Entrepreneur_Email] FROM INSERTED WHERE (((([State] = 'Pendiente de revision') OR ([State] = 'Aceptado')) OR ([State] = 'Rechazado')) AND ([Entrepreneur_Email] = 'saguilar1999@hotmail.com'))
=======
            INSERT INTO @modifiedRecordsTable SELECT [Client_Email], [State], [View] FROM INSERTED WHERE ((([State] = 'Aceptado') OR ([State] = 'Rechazado')) AND ([Client_Email] = 'soru1097@gmail.com'))
>>>>>>> Develop
        END
        ELSE
        BEGIN
            SET @dmlType = 'Update';
<<<<<<< HEAD
            INSERT INTO @deletedTable SELECT [State],[Entrepreneur_Email] FROM DELETED
            INSERT INTO @insertedTable SELECT [State],[Entrepreneur_Email] FROM INSERTED
            INSERT INTO @exceptTable SELECT [RowNumber],[State],[Entrepreneur_Email] FROM @insertedTable EXCEPT SELECT [RowNumber],[State],[Entrepreneur_Email] FROM @deletedTable

            INSERT INTO @modifiedRecordsTable SELECT [State],[Entrepreneur_Email] FROM @exceptTable e WHERE (((([State] = 'Pendiente de revision') OR ([State] = 'Aceptado')) OR ([State] = 'Rechazado')) AND ([Entrepreneur_Email] = 'saguilar1999@hotmail.com'))
=======
            INSERT INTO @deletedTable SELECT [Client_Email],[State],[View] FROM DELETED
            INSERT INTO @insertedTable SELECT [Client_Email],[State],[View] FROM INSERTED
            INSERT INTO @exceptTable SELECT [RowNumber],[Client_Email],[State],[View] FROM @insertedTable EXCEPT SELECT [RowNumber],[Client_Email],[State],[View] FROM @deletedTable

            INSERT INTO @modifiedRecordsTable SELECT [Client_Email],[State],[View] FROM @exceptTable e WHERE ((([State] = 'Aceptado') OR ([State] = 'Rechazado')) AND ([Client_Email] = 'soru1097@gmail.com'))
>>>>>>> Develop
        END
    END

    SELECT @rowsToProcess = COUNT(1) FROM @modifiedRecordsTable    

    BEGIN TRY
        WHILE @rowsToProcess > 0
        BEGIN
<<<<<<< HEAD
            SELECT	@var1 = [State], @var2 = [Entrepreneur_Email]
=======
            SELECT	@var1 = [Client_Email], @var2 = [State], @var3 = [View]
>>>>>>> Develop
            FROM	@modifiedRecordsTable
            WHERE	[RowNumber] = @rowsToProcess
                
            IF @dmlType = 'Insert' 
            BEGIN
<<<<<<< HEAD
                ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/StartMessage/Insert] (CONVERT(NVARCHAR, @dmlType))

                IF @var1 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/State] (CONVERT(NVARCHAR(MAX), @var1))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/State] (0x)
                END
                IF @var2 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/Entrepreneur_Email] (CONVERT(NVARCHAR(MAX), @var2))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/Entrepreneur_Email] (0x)
                END

                ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/EndMessage] (0x)
=======
                ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/StartMessage/Insert] (CONVERT(NVARCHAR, @dmlType))

                IF @var1 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/Client_Email] (CONVERT(NVARCHAR(MAX), @var1))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/Client_Email] (0x)
                END
                IF @var2 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/State] (CONVERT(NVARCHAR(MAX), @var2))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/State] (0x)
                END
                IF @var3 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/View] (CONVERT(NVARCHAR(MAX), @var3))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/View] (0x)
                END

                ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/EndMessage] (0x)
>>>>>>> Develop
            END
        
            IF @dmlType = 'Update'
            BEGIN
<<<<<<< HEAD
                ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/StartMessage/Update] (CONVERT(NVARCHAR, @dmlType))

                IF @var1 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/State] (CONVERT(NVARCHAR(MAX), @var1))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/State] (0x)
                END
                IF @var2 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/Entrepreneur_Email] (CONVERT(NVARCHAR(MAX), @var2))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/Entrepreneur_Email] (0x)
                END

                ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/EndMessage] (0x)
=======
                ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/StartMessage/Update] (CONVERT(NVARCHAR, @dmlType))

                IF @var1 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/Client_Email] (CONVERT(NVARCHAR(MAX), @var1))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/Client_Email] (0x)
                END
                IF @var2 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/State] (CONVERT(NVARCHAR(MAX), @var2))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/State] (0x)
                END
                IF @var3 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/View] (CONVERT(NVARCHAR(MAX), @var3))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/View] (0x)
                END

                ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/EndMessage] (0x)
>>>>>>> Develop
            END

            IF @dmlType = 'Delete'
            BEGIN
<<<<<<< HEAD
                ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/StartMessage/Delete] (CONVERT(NVARCHAR, @dmlType))

                IF @var1 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/State] (CONVERT(NVARCHAR(MAX), @var1))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/State] (0x)
                END
                IF @var2 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/Entrepreneur_Email] (CONVERT(NVARCHAR(MAX), @var2))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/Entrepreneur_Email] (0x)
                END

                ;SEND ON CONVERSATION '2195a93b-74ea-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_a58d2bf2-1ddb-47b7-9505-242228136070/EndMessage] (0x)
=======
                ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/StartMessage/Delete] (CONVERT(NVARCHAR, @dmlType))

                IF @var1 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/Client_Email] (CONVERT(NVARCHAR(MAX), @var1))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/Client_Email] (0x)
                END
                IF @var2 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/State] (CONVERT(NVARCHAR(MAX), @var2))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/State] (0x)
                END
                IF @var3 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/View] (CONVERT(NVARCHAR(MAX), @var3))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/View] (0x)
                END

                ;SEND ON CONVERSATION 'eba679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Order_93be83e7-94c6-4d25-9fdf-3961662fca97/EndMessage] (0x)
>>>>>>> Develop
            END

            SET @rowsToProcess = @rowsToProcess - 1
        END
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000)
        DECLARE @ErrorSeverity INT
        DECLARE @ErrorState INT

        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE()

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState) 
    END CATCH
END
CREATE TABLE [dbo].[Shopping_Cart_Has] (
    [Email]              VARCHAR (100) NOT NULL,
    [Code_ID]            INT           NOT NULL,
    [Entrepreneur_Email] VARCHAR (100) NOT NULL,
    [Category_ID]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Email] ASC, [Code_ID] ASC, [Entrepreneur_Email] ASC, [Category_ID] ASC),
    CONSTRAINT [FK_dbo.Shopping_Cart_Has_dbo.Product_Service] FOREIGN KEY ([Code_ID], [Entrepreneur_Email], [Category_ID]) REFERENCES [dbo].[Product_Service] ([Code_ID], [Entrepreneur_Email], [Category_ID]),
    CONSTRAINT [FK_dbo.Shopping_Cart_Has_dbo.Shopping_Cart] FOREIGN KEY ([Email]) REFERENCES [dbo].[Shopping_Cart] ([Email]) ON DELETE CASCADE ON UPDATE CASCADE
);


<<<<<<< HEAD
=======










>>>>>>> Develop
GO
CREATE NONCLUSTERED INDEX [emailSecondaryIndex]
    ON [dbo].[Shopping_Cart_Has]([Email] ASC);


GO
CREATE TRIGGER [tr_dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Sender] ON [dbo].[Shopping_Cart_Has] 
WITH EXECUTE AS SELF
AFTER insert, update, delete AS 
BEGIN
    SET NOCOUNT ON;

    DECLARE @rowsToProcess INT
    DECLARE @currentRow INT
    DECLARE @records XML
    DECLARE @theMessageContainer NVARCHAR(MAX)
    DECLARE @dmlType NVARCHAR(10)
    DECLARE @modifiedRecordsTable TABLE ([RowNumber] INT IDENTITY(1, 1), [Email] varchar(100), [Code_ID] int, [Entrepreneur_Email] varchar(100), [Category_ID] int)
    DECLARE @exceptTable TABLE ([RowNumber] INT, [Email] varchar(100), [Code_ID] int, [Entrepreneur_Email] varchar(100), [Category_ID] int)
	DECLARE @deletedTable TABLE ([RowNumber] INT IDENTITY(1, 1), [Email] varchar(100), [Code_ID] int, [Entrepreneur_Email] varchar(100), [Category_ID] int)
    DECLARE @insertedTable TABLE ([RowNumber] INT IDENTITY(1, 1), [Email] varchar(100), [Code_ID] int, [Entrepreneur_Email] varchar(100), [Category_ID] int)
    DECLARE @var1 varchar(100)
    DECLARE @var2 int
    DECLARE @var3 varchar(100)
    DECLARE @var4 int

    DECLARE @conversationHandlerExists INT
    SELECT @conversationHandlerExists = COUNT(*) FROM sys.conversation_endpoints WHERE conversation_handle = 'e9a679eb-4ceb-eb11-b46b-d7085749938a';
    IF @conversationHandlerExists = 0
    BEGIN
        DECLARE @conversation_handle UNIQUEIDENTIFIER;
        DECLARE @schema_id INT;
        SELECT @schema_id = schema_id FROM sys.schemas WITH (NOLOCK) WHERE name = N'dbo';

        
        IF EXISTS (SELECT * FROM sys.triggers WITH (NOLOCK) WHERE object_id = OBJECT_ID(N'[dbo].[tr_dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Sender]')) DROP TRIGGER [dbo].[tr_dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Sender') EXEC (N'ALTER QUEUE [dbo].[dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Sender] WITH ACTIVATION (STATUS = OFF)');

        
        SELECT conversation_handle INTO #Conversations FROM sys.conversation_endpoints WITH (NOLOCK) WHERE far_service LIKE N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_%' ORDER BY is_initiator ASC;
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

        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Receiver') DROP SERVICE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Receiver];
        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Sender') DROP SERVICE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Receiver') DROP QUEUE [dbo].[dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Receiver];
        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Sender') DROP QUEUE [dbo].[dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_contracts WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59') DROP CONTRACT [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59];
        
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/StartMessage/Insert') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/StartMessage/Insert];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/StartMessage/Update') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/StartMessage/Update];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/StartMessage/Delete') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/StartMessage/Delete];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Email') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Email];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Code_ID') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Code_ID];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Entrepreneur_Email') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Entrepreneur_Email];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Category_ID') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Category_ID];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/EndMessage') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/EndMessage];

        
        IF EXISTS (SELECT * FROM sys.objects WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_QueueActivationSender') DROP PROCEDURE [dbo].[dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59_QueueActivationSender];
        RETURN
    END
    
    IF NOT EXISTS(SELECT 1 FROM INSERTED)
    BEGIN
        SET @dmlType = 'Delete'
        INSERT INTO @modifiedRecordsTable SELECT [Email], [Code_ID], [Entrepreneur_Email], [Category_ID] FROM DELETED WHERE ([Email] = 'soru1097@gmail.com')
    END
    ELSE
    BEGIN
        IF NOT EXISTS(SELECT * FROM DELETED)
        BEGIN
            SET @dmlType = 'Insert'
            INSERT INTO @modifiedRecordsTable SELECT [Email], [Code_ID], [Entrepreneur_Email], [Category_ID] FROM INSERTED WHERE ([Email] = 'soru1097@gmail.com')
        END
        ELSE
        BEGIN
            SET @dmlType = 'Update';
            INSERT INTO @deletedTable SELECT [Email],[Code_ID],[Entrepreneur_Email],[Category_ID] FROM DELETED
            INSERT INTO @insertedTable SELECT [Email],[Code_ID],[Entrepreneur_Email],[Category_ID] FROM INSERTED
            INSERT INTO @exceptTable SELECT [RowNumber],[Email],[Code_ID],[Entrepreneur_Email],[Category_ID] FROM @insertedTable EXCEPT SELECT [RowNumber],[Email],[Code_ID],[Entrepreneur_Email],[Category_ID] FROM @deletedTable

            INSERT INTO @modifiedRecordsTable SELECT [Email],[Code_ID],[Entrepreneur_Email],[Category_ID] FROM @exceptTable e WHERE ([Email] = 'soru1097@gmail.com')
        END
    END

    SELECT @rowsToProcess = COUNT(1) FROM @modifiedRecordsTable    

    BEGIN TRY
        WHILE @rowsToProcess > 0
        BEGIN
            SELECT	@var1 = [Email], @var2 = [Code_ID], @var3 = [Entrepreneur_Email], @var4 = [Category_ID]
            FROM	@modifiedRecordsTable
            WHERE	[RowNumber] = @rowsToProcess
                
            IF @dmlType = 'Insert' 
            BEGIN
                ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/StartMessage/Insert] (CONVERT(NVARCHAR, @dmlType))

                IF @var1 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Email] (CONVERT(NVARCHAR(MAX), @var1))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Email] (0x)
                END
                IF @var2 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Code_ID] (CONVERT(NVARCHAR(MAX), @var2))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Code_ID] (0x)
                END
                IF @var3 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Entrepreneur_Email] (CONVERT(NVARCHAR(MAX), @var3))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Entrepreneur_Email] (0x)
                END
                IF @var4 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Category_ID] (CONVERT(NVARCHAR(MAX), @var4))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Category_ID] (0x)
                END

                ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/EndMessage] (0x)
            END
        
            IF @dmlType = 'Update'
            BEGIN
                ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/StartMessage/Update] (CONVERT(NVARCHAR, @dmlType))

                IF @var1 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Email] (CONVERT(NVARCHAR(MAX), @var1))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Email] (0x)
                END
                IF @var2 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Code_ID] (CONVERT(NVARCHAR(MAX), @var2))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Code_ID] (0x)
                END
                IF @var3 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Entrepreneur_Email] (CONVERT(NVARCHAR(MAX), @var3))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Entrepreneur_Email] (0x)
                END
                IF @var4 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Category_ID] (CONVERT(NVARCHAR(MAX), @var4))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Category_ID] (0x)
                END

                ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/EndMessage] (0x)
            END

            IF @dmlType = 'Delete'
            BEGIN
                ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/StartMessage/Delete] (CONVERT(NVARCHAR, @dmlType))

                IF @var1 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Email] (CONVERT(NVARCHAR(MAX), @var1))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Email] (0x)
                END
                IF @var2 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Code_ID] (CONVERT(NVARCHAR(MAX), @var2))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Code_ID] (0x)
                END
                IF @var3 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Entrepreneur_Email] (CONVERT(NVARCHAR(MAX), @var3))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Entrepreneur_Email] (0x)
                END
                IF @var4 IS NOT NULL BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Category_ID] (CONVERT(NVARCHAR(MAX), @var4))
                END
                ELSE BEGIN
                    ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/Category_ID] (0x)
                END

                ;SEND ON CONVERSATION 'e9a679eb-4ceb-eb11-b46b-d7085749938a' MESSAGE TYPE [dbo_Shopping_Cart_Has_9db8d40f-f493-445d-8cb4-6ca4be0eaf59/EndMessage] (0x)
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
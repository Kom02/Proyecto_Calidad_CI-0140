CREATE PROCEDURE [dbo].[dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_QueueActivationSender] 
WITH EXECUTE AS SELF
AS 
BEGIN 
    SET NOCOUNT ON;
    DECLARE @h AS UNIQUEIDENTIFIER;
    DECLARE @mt NVARCHAR(200);

    RECEIVE TOP(1) @h = conversation_handle, @mt = message_type_name FROM [dbo].[dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender];

    IF @mt = N'http://schemas.microsoft.com/SQL/ServiceBroker/EndDialog'
    BEGIN
        END CONVERSATION @h;
    END

    IF @mt = N'http://schemas.microsoft.com/SQL/ServiceBroker/DialogTimer' OR @mt = N'http://schemas.microsoft.com/SQL/ServiceBroker/Error'
    BEGIN 
        

        END CONVERSATION @h;

        DECLARE @conversation_handle UNIQUEIDENTIFIER;
        DECLARE @schema_id INT;
        SELECT @schema_id = schema_id FROM sys.schemas WITH (NOLOCK) WHERE name = N'dbo';

        
        IF EXISTS (SELECT * FROM sys.triggers WITH (NOLOCK) WHERE object_id = OBJECT_ID(N'[dbo].[tr_dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender]')) DROP TRIGGER [dbo].[tr_dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender') EXEC (N'ALTER QUEUE [dbo].[dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender] WITH ACTIVATION (STATUS = OFF)');

        
        SELECT conversation_handle INTO #Conversations FROM sys.conversation_endpoints WITH (NOLOCK) WHERE far_service LIKE N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_%' ORDER BY is_initiator ASC;
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

        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Receiver') DROP SERVICE [dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Receiver];
        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender') DROP SERVICE [dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Receiver') DROP QUEUE [dbo].[dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Receiver];
        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender') DROP QUEUE [dbo].[dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_contracts WITH (NOLOCK) WHERE name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270') DROP CONTRACT [dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270];
        
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/StartMessage/Insert') DROP MESSAGE TYPE [dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/StartMessage/Insert];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/StartMessage/Update') DROP MESSAGE TYPE [dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/StartMessage/Update];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/StartMessage/Delete') DROP MESSAGE TYPE [dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/StartMessage/Delete];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/State') DROP MESSAGE TYPE [dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/State];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/Entrepreneur_Email') DROP MESSAGE TYPE [dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/Entrepreneur_Email];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/EndMessage') DROP MESSAGE TYPE [dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270/EndMessage];

        
        IF EXISTS (SELECT * FROM sys.objects WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_QueueActivationSender') DROP PROCEDURE [dbo].[dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_QueueActivationSender];

        
    END
END
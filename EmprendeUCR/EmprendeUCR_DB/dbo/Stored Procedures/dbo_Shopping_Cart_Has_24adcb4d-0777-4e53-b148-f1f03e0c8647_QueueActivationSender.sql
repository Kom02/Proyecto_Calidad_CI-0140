﻿CREATE PROCEDURE [dbo].[dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_QueueActivationSender] 
WITH EXECUTE AS SELF
AS 
BEGIN 
    SET NOCOUNT ON;
    DECLARE @h AS UNIQUEIDENTIFIER;
    DECLARE @mt NVARCHAR(200);

    RECEIVE TOP(1) @h = conversation_handle, @mt = message_type_name FROM [dbo].[dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender];

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

        
        IF EXISTS (SELECT * FROM sys.triggers WITH (NOLOCK) WHERE object_id = OBJECT_ID(N'[dbo].[tr_dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender]')) DROP TRIGGER [dbo].[tr_dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender') EXEC (N'ALTER QUEUE [dbo].[dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender] WITH ACTIVATION (STATUS = OFF)');

        
        SELECT conversation_handle INTO #Conversations FROM sys.conversation_endpoints WITH (NOLOCK) WHERE far_service LIKE N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_%' ORDER BY is_initiator ASC;
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

        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Receiver') DROP SERVICE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Receiver];
        
        IF EXISTS (SELECT * FROM sys.services WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender') DROP SERVICE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Receiver') DROP QUEUE [dbo].[dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Receiver];
        
        IF EXISTS (SELECT * FROM sys.service_queues WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender') DROP QUEUE [dbo].[dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender];

        
        IF EXISTS (SELECT * FROM sys.service_contracts WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647') DROP CONTRACT [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647];
        
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/StartMessage/Insert') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/StartMessage/Insert];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/StartMessage/Update') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/StartMessage/Update];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/StartMessage/Delete') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/StartMessage/Delete];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/Email') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/Email];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/Code_ID') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/Code_ID];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/Entrepreneur_Email') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/Entrepreneur_Email];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/Category_ID') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/Category_ID];
        IF EXISTS (SELECT * FROM sys.service_message_types WITH (NOLOCK) WHERE name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/EndMessage') DROP MESSAGE TYPE [dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647/EndMessage];

        
        IF EXISTS (SELECT * FROM sys.objects WITH (NOLOCK) WHERE schema_id = @schema_id AND name = N'dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_QueueActivationSender') DROP PROCEDURE [dbo].[dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_QueueActivationSender];

        
    END
END
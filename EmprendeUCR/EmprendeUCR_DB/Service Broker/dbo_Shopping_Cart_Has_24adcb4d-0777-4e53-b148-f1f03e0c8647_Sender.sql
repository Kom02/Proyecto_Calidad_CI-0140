CREATE QUEUE [dbo].[dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_Sender]
    WITH POISON_MESSAGE_HANDLING(STATUS = OFF), ACTIVATION (STATUS = ON, PROCEDURE_NAME = [dbo].[dbo_Shopping_Cart_Has_24adcb4d-0777-4e53-b148-f1f03e0c8647_QueueActivationSender], MAX_QUEUE_READERS = 1, EXECUTE AS N'EmprendeAdmin');


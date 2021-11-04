CREATE QUEUE [dbo].[dbo_Shopping_Cart_Has_60227979-2fa7-4bb9-bf87-a56f6bd1031e_Sender]
    WITH POISON_MESSAGE_HANDLING(STATUS = OFF), ACTIVATION (STATUS = ON, PROCEDURE_NAME = [dbo].[dbo_Shopping_Cart_Has_60227979-2fa7-4bb9-bf87-a56f6bd1031e_QueueActivationSender], MAX_QUEUE_READERS = 1, EXECUTE AS N'EmprendeAdmin');


CREATE QUEUE [dbo].[dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_Sender]
    WITH POISON_MESSAGE_HANDLING(STATUS = OFF), ACTIVATION (STATUS = ON, PROCEDURE_NAME = [dbo].[dbo_Order_72d67f66-4d4e-49ad-9fc4-0488fdcab270_QueueActivationSender], MAX_QUEUE_READERS = 1, EXECUTE AS N'EmprendeAdmin');


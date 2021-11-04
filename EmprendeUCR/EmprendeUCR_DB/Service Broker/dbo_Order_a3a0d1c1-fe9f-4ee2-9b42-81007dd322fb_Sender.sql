CREATE QUEUE [dbo].[dbo_Order_a3a0d1c1-fe9f-4ee2-9b42-81007dd322fb_Sender]
    WITH POISON_MESSAGE_HANDLING(STATUS = OFF), ACTIVATION (STATUS = ON, PROCEDURE_NAME = [dbo].[dbo_Order_a3a0d1c1-fe9f-4ee2-9b42-81007dd322fb_QueueActivationSender], MAX_QUEUE_READERS = 1, EXECUTE AS N'EmprendeAdmin');


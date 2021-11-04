CREATE QUEUE [dbo].[dbo_Shopping_Cart_Has_26f02240-de1b-44f7-bdd9-a39326dcf160_Sender]
    WITH POISON_MESSAGE_HANDLING(STATUS = OFF), ACTIVATION (STATUS = ON, PROCEDURE_NAME = [dbo].[dbo_Shopping_Cart_Has_26f02240-de1b-44f7-bdd9-a39326dcf160_QueueActivationSender], MAX_QUEUE_READERS = 1, EXECUTE AS N'EmprendeAdmin');


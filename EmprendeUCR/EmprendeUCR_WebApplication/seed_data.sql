use DB_Test;

delete from [Order];
delete from [Personalized_Status];
delete from [Generic_Status];
delete from [Status];
delete from [Likes];
delete from [Shopping_Cart_Has];
delete from [Shopping_Cart];
delete from [Product];
delete from [Product_Service];
delete from [ActiveAdministrators];
delete from [Likes];
delete from [Phones];
delete from [Email_Confirmation];
delete from [Credentials];
delete from [Administrator];
delete from [Members];
delete from [Entrepreneur];
delete from [Client];
delete from [User];

MERGE INTO [User] AS Target
USING (VALUES 
        ('juan.valverde@ucr.ac.cr','Juan','Valverde','Campos', NULL, NULL, NULL, NULL, NULL),
        ('saguilar1999@hotmail.com','Silvia','Aguilar','Guerrero', NULL, NULL, NULL, NULL, NULL),
        ('cuenta.user@gmail.com', 'Cuenta', 'User', 'Test', '1999-07-30', 'Alajuela', 'Alajuela', 'Alajuela', 1),
        ('update.user@gmail.com', 'Update', 'User', 'Test', '1999-07-30', 'Alajuela', 'Alajuela', 'Alajuela', 1),
        ('add.member@gmail.com', 'Add', 'Member', 'Test', '1999-07-30', 'Alajuela', 'Alajuela', 'Alajuela', 1),
        ('add.client@gmail.com', 'Add', 'Client', 'Test', '1999-07-30', 'Alajuela', 'Alajuela', 'Alajuela', 1),
        ('shop.cart@gmail.com', 'Shop', 'Cart', 'Test', '1999-07-30', 'Alajuela', 'Alajuela', 'Alajuela', 1),
        ('add.entrepreneur@gmail.com', 'Add', 'Entrepreneur', 'Test', '1999-07-30', 'Alajuela', 'Alajuela', 'Alajuela', 1),
        ('add.admin@gmail.com', 'Add', 'Admin', 'Test', '1999-07-30', 'Alajuela', 'Alajuela', 'Alajuela', 1),
        ('cuenta.admin@gmail.com', 'Cuenta', 'Admin', 'Test', '1999-07-30', 'Alajuela', 'Alajuela', 'Alajuela', 1),
        ('email.confirm@gmail.com', 'Email', 'Confirm', 'Test', '1999-07-30', 'Alajuela', 'Alajuela', 'Alajuela', 1)
)
AS Source ([Email], [Name], [F_Last_Name], [S_Last_Name], [Birth_Date], [Province_Name], [Canton_Name], [District_Name], [Email_Confirmation]) 
ON Target.[Email] = Source.[Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Email], [Name], [F_Last_Name], [S_Last_Name], [Birth_Date], [Province_Name], [Canton_Name], [District_Name], [Email_Confirmation]) 
VALUES ([Email], [Name], [F_Last_Name], [S_Last_Name], [Birth_Date], [Province_Name], [Canton_Name], [District_Name], [Email_Confirmation]); 


MERGE INTO Members AS Target
USING (VALUES
        ('juan.valverde@ucr.ac.cr', 0, NULL, NULL),
        ('add.client@gmail.com', 0, 0.0, 0.0),
        ('shop.cart@gmail.com', 0, 0.0, 0.0),
        ('add.entrepreneur@gmail.com', 0, 0.0, 0.0)
)
AS Source ([User_Email], [Score], [Lat], [Long]) 
ON Target.[User_Email] = Source.[User_Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([User_Email], [Score], [Lat], [Long]) 
VALUES ([User_Email], [Score], [Lat], [Long]);


MERGE INTO Client AS Target
USING (VALUES
        ('juan.valverde@ucr.ac.cr'),
        ('shop.cart@gmail.com')
)
AS Source ([User_Email]) 
ON Target.[User_Email] = Source.[User_Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([User_Email]) 
VALUES ([User_Email]);


MERGE INTO Administrator AS Target
USING (VALUES
        ('cuenta.admin@gmail.com')
)
AS Source ([User_Email]) 
ON Target.[User_Email] = Source.[User_Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([User_Email]) 
VALUES ([User_Email]);

MERGE INTO Entrepreneur AS Target
USING (VALUES
        ('saguilar1999@hotmail.com', NULL)
)
AS Source ([User_Email], [Presentation]) 
ON Target.[User_Email] = Source.[User_Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([User_Email], [Presentation]) 
VALUES ([User_Email], [Presentation]);

MERGE INTO [Credentials] AS Target
USING (VALUES
    ('juan.valverde@ucr.ac.cr', 'contraJuan'),
    ('saguilar1999@hotmail.com', 'contraSilvia')
)
AS Source ([User_Email], [Password])
ON Target.[User_Email] = source.[User_Email]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([User_Email], [Password])
VALUES ([User_Email], [Password]);

MERGE INTO [Email_Confirmation] AS Target
USING (VALUES
    ('juan.valverde@ucr.ac.cr', 'hashJuan', '2020-10-10', '2021-10-10'),
    ('saguilar1999@hotmail.com', 'hashSilvia', '2020-10-10', '2021-10-10')
)
AS Source ([Email], [Hash_Code], [Creation_Date], [Expiration_Date])
ON Target.[Email] = source.[Email]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Email], [Hash_Code], [Creation_Date], [Expiration_Date])
VALUES ([Email], [Hash_Code], [Creation_Date], [Expiration_Date]);

SET IDENTITY_INSERT [Category]  on 
MERGE INTO Category AS Target
USING (VALUES
        ('Bebidas', NULL, NULL, 10),
        ('Electrodomesticos', NULL, NULL, 1),
        ('Juguetes', NULL, NULL, 2),
        ('Comidas', NULL, NULL, 3),
        ('Ropa', NULL, NULL, 4),
        ('Camisas', NULL, 4, 5),
        ('Pantalones', NULL, 4, 6),
        ('Shorts', NULL, 4, 7)
)
AS Source ([Title], [Description], [ParentId], [Id]) 
ON Target.[Id] = Source.[Id] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Title], [Description], [ParentId], [Id]) 
VALUES ([Title], [Description], [ParentId], [Id]); 
SET IDENTITY_INSERT [Category]  off 


SET IDENTITY_INSERT [Product_Service]  on 
MERGE INTO Product_Service AS Target
USING (VALUES 
        (100, 'saguilar1999@hotmail.com', 20, 10),
        (101, 'saguilar1999@hotmail.com', 5, 10),
        (102, 'saguilar1999@hotmail.com', 100, 10),
        (103, 'saguilar1999@hotmail.com', 10, 10)
)
AS Source ([Code_ID], [Entrepreneur_Email], [Availability], [Category_ID]) 
ON Target.[Code_ID] = Source.[Code_ID] AND Target.[Entrepreneur_Email] = Source.[Entrepreneur_Email] AND 
   Target.[Category_ID] = Source.[Category_ID]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Code_ID], [Entrepreneur_Email], [Availability], [Category_ID]) 
VALUES ([Code_ID], [Entrepreneur_Email], [Availability], [Category_ID]); 
SET IDENTITY_INSERT [Product_Service]  off 


MERGE INTO Product AS Target
USING (VALUES 
        (100, 'Cafe Maria tostado', NULL, 1500, 'saguilar1999@hotmail.com', 10),
        (101, 'Cafe de murcielago', NULL, 2000, 'saguilar1999@hotmail.com', 10),
        (102, 'Cafe sin tostar', NULL, 1000, 'saguilar1999@hotmail.com', 10),
        (103, 'Cafe de vaca molido en su punto', NULL, 10000, 'saguilar1999@hotmail.com', 10)
)
AS Source ([Code_ID], [Product_Name], [Product_Description], [Price], [Entrepreneur_Email], [Category_ID]) 
ON Target.[Code_ID] = Source.[Code_ID] AND Target.[Entrepreneur_Email] = Source.[Entrepreneur_Email] AND 
   Target.[Category_ID] = Source.[Category_ID]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Code_ID], [Product_Name], [Product_Description], [Price], [Entrepreneur_Email], [Category_ID]) 
VALUES ([Code_ID], [Product_Name], [Product_Description], [Price], [Entrepreneur_Email], [Category_ID]); 


MERGE INTO Shopping_Cart AS Target
USING (VALUES
        ('juan.valverde@ucr.ac.cr')
)
AS Source ([Email]) 
ON Target.[Email] = Source.[Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Email]) 
VALUES ([Email]); 

MERGE INTO Shopping_Cart_Has AS Target
USING (VALUES
        ('juan.valverde@ucr.ac.cr', 500, 'saguilar1999@hotmail.com', 10),
        ('juan.valverde@ucr.ac.cr', 508, 'saguilar1999@hotmail.com', 2),
        ('juan.valverde@ucr.ac.cr', 507, 'saguilar1999@hotmail.com', 2),
        ('juan.valverde@ucr.ac.cr', 506, 'saguilar1999@hotmail.com', 11),
        ('juan.valverde@ucr.ac.cr', 505, 'saguilar1999@hotmail.com', 2)
)
AS Source ([Email], [Code_ID], [Entrepreneur_Email], [Category_ID]) 
ON Target.[Email] = Source.[Email] AND Target.[Code_ID] = Source.[Code_ID] AND
   Target.[Entrepreneur_Email] = Source.[Entrepreneur_Email] AND Target.[Category_ID] = Source.[Category_ID]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Email], [Code_ID], [Entrepreneur_Email], [Category_ID]) 
VALUES ([Email], [Code_ID], [Entrepreneur_Email], [Category_ID]);

MERGE INTO Status AS Target
USING (VALUES
        ('Pendiente de revision', NULL),
		('Rechazado', 'Pendiente de revision'),
		('Aceptado', 'Pendiente de revision'),
		('En progreso', 'Aceptado'),
        ('Listo para entrega', 'En progreso'),
        ('Finalizado', 'Listo para entrega')
)
AS Source ([Name], [Previous_State_Name]) 
ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name], [Previous_State_Name]) 
VALUES ([Name], [Previous_State_Name]);

MERGE INTO Generic_Status AS Target
USING (VALUES
        ('Pendiente de revision'),
		('Rechazado'),
		('Aceptado'),
		('En progreso'),
        ('Listo para entrega'),
        ('Finalizado')
)
AS Source ([Name]) 
ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name]) 
VALUES ([Name]);

MERGE INTO Status AS Target
USING (VALUES
        ('Cocinando', NULL),
        ('Envolviendo', NULL),
        ('Creando', NULL)
)
AS Source ([Name], [Previous_State_Name]) 
ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name], [Previous_State_Name]) 
VALUES ([Name], [Previous_State_Name]);

MERGE INTO Personalized_Status AS Target
USING (VALUES
        ('Cocinando'),
        ('Envolviendo'),
        ('Creando')
)
AS Source ([Name]) 
ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name]) 
VALUES ([Name]);

MERGE INTO [Order] AS Target
USING (VALUES
        ('2021-06-10 17:15:23.000','juan.valverde@ucr.ac.cr', '2021-07-30' , 'saguilar1999@hotmail.com', 'Pendiente de revision'),
        ('2021-08-10 17:15:23.000','juan.valverde@ucr.ac.cr', '2021-07-30' , 'saguilar1999@hotmail.com', 'Pendiente de revision'),
        ('2021-09-10 17:15:23.000','juan.valverde@ucr.ac.cr', '2021-07-30' , 'saguilar1999@hotmail.com', 'Aceptado'),
        ('2021-10-10 17:15:23.000','juan.valverde@ucr.ac.cr', '2021-07-30' , 'saguilar1999@hotmail.com', 'Aceptado'),
        ('2021-11-10 17:15:23.000','juan.valverde@ucr.ac.cr', '2021-07-30' , 'saguilar1999@hotmail.com', 'Aceptado')
)
AS Source ([Date_and_hour_of_creation], [Client_Email], [Delivery_date], [Entrepreneur_Email], [State]) 
ON Target.[Date_and_hour_of_creation] = Source.[Date_and_hour_of_creation] AND Target.[Client_Email] = Source.[Client_Email]
   AND Target.[Delivery_date] = Source.[Delivery_date] AND Target.[Entrepreneur_Email] = Source.[Entrepreneur_Email] AND Target.[State] = Source.[State]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Date_and_hour_of_creation], [Client_Email], [Delivery_date], [Entrepreneur_Email], [State]) 
VALUES ([Date_and_hour_of_creation], [Client_Email], [Delivery_date], [Entrepreneur_Email], [State]);

MERGE INTO ActiveAdministrators AS TARGET
USING (VALUES
       ('cuenta.admin@gmail.com', '2021-06-10 17:15:23.000', 1, 1, 1, '2021-06-13 13:17:40.000')
)
AS Source ([Email], Creation_Date, Response, Confirm, Active, Response_Date)
ON Target.[Email] = Source.[Email]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Email], Creation_Date, Response, Confirm, Active, Response_Date)
VALUES ([Email], Creation_Date, Response, Confirm, Active, Response_Date);

MERGE INTO [Email_Confirmation] AS TARGET
USING (VALUES
    ('email.confirm@gmail.com', 'asdkljaljfha', '2021-07-20', '2021-09-10')
)
AS Source ([Email], [Hash_Code], [Creation_Date], [Expiration_Date])
ON TARGET.[Email] = Source.[Email]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Email], [Hash_Code], [Creation_Date], [Expiration_Date])
VALUES ([Email], [Hash_Code], [Creation_Date], [Expiration_Date]);

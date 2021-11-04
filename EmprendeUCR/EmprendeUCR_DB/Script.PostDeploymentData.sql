/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO [User] AS Target
USING (VALUES 
        ('juan.valverde@ucr.ac.cr','Juan','Valverde','Campos', NULL, 'Puntarenas', 'Coto Brus', 'San Vito', NULL),
        ('silvia.aguilarguerrero@ucr.ac.cr','Silvia','Aguilar','Guerrero', NULL, 'San José', 'Goicoechea', 'Guadalupe', NULL)
)
AS Source ([Email], [Name], [F_Last_Name], [S_Last_Name], [Birth_Date], [Province_Name], [Canton_Name], [District_Name], [Email_Confirmation]) 
ON Target.[Email] = Source.[Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Email], [Name], [F_Last_Name], [S_Last_Name], [Birth_Date], [Province_Name], [Canton_Name], [District_Name], [Email_Confirmation]) 
VALUES ([Email], [Name], [F_Last_Name], [S_Last_Name], [Birth_Date], [Province_Name], [Canton_Name], [District_Name], [Email_Confirmation]); 


MERGE INTO Members AS Target
USING (VALUES
        ('silvia.aguilarguerrero@ucr.ac.cr', 0, NULL, NULL)
)
AS Source ([User_Email], [Score], [Lat], [Long]) 
ON Target.[User_Email] = Source.[User_Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([User_Email], [Score], [Lat], [Long]) 
VALUES ([User_Email], [Score], [Lat], [Long]);


MERGE INTO Client AS Target
USING (VALUES
        ('silvia.aguilarguerrero@ucr.ac.cr')
)
AS Source ([User_Email]) 
ON Target.[User_Email] = Source.[User_Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([User_Email]) 
VALUES ([User_Email]);


MERGE INTO Entrepreneur AS Target
USING (VALUES
        ('juan.valverde@ucr.ac.cr', NULL)
)
AS Source ([User_Email], [Presentation]) 
ON Target.[User_Email] = Source.[User_Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([User_Email], [Presentation]) 
VALUES ([User_Email], [Presentation]); 


SET IDENTITY_INSERT [Category]  on 
MERGE INTO Category AS Target
USING (VALUES
        ('Bebidas', NULL, NULL, 10)
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
        (100, 'juan.valverde@ucr.ac.cr', 20, 10),
        (101, 'juan.valverde@ucr.ac.cr', 5, 10),
        (102, 'juan.valverde@ucr.ac.cr', 100, 10),
        (103, 'juan.valverde@ucr.ac.cr', 10, 10)
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
        (100, 'Cafe Maria tostado', NULL, 1500, 'juan.valverde@ucr.ac.cr', 10),
        (101, 'Cafe de murcielago', NULL, 2000, 'juan.valverde@ucr.ac.cr', 10),
        (102, 'Cafe sin tostar', NULL, 1000, 'juan.valverde@ucr.ac.cr', 10),
        (103, 'Cafe de vaca molido en su punto', NULL, 10000, 'juan.valverde@ucr.ac.cr', 10)
)
AS Source ([Code_ID], [Product_Name], [Product_Description], [Price], [Entrepreneur_Email], [Category_ID]) 
ON Target.[Code_ID] = Source.[Code_ID] AND Target.[Entrepreneur_Email] = Source.[Entrepreneur_Email] AND 
   Target.[Category_ID] = Source.[Category_ID]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Code_ID], [Product_Name], [Product_Description], [Price], [Entrepreneur_Email], [Category_ID]) 
VALUES ([Code_ID], [Product_Name], [Product_Description], [Price], [Entrepreneur_Email], [Category_ID]); 


MERGE INTO Shopping_Cart AS Target
USING (VALUES
        ('silvia.aguilarguerrero@ucr.ac.cr')
)
AS Source ([Email]) 
ON Target.[Email] = Source.[Email] 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Email]) 
VALUES ([Email]); 


MERGE INTO Shopping_Cart_Has AS Target
USING (VALUES
        ('silvia.aguilarguerrero@ucr.ac.cr', 100, 'juan.valverde@ucr.ac.cr', 10),
		('silvia.aguilarguerrero@ucr.ac.cr', 101, 'juan.valverde@ucr.ac.cr', 10),
		('silvia.aguilarguerrero@ucr.ac.cr', 102, 'juan.valverde@ucr.ac.cr', 10),
		('silvia.aguilarguerrero@ucr.ac.cr', 103, 'juan.valverde@ucr.ac.cr', 10)
)
AS Source ([Email], [Code_ID], [Entrepreneur_Email], [Category_ID]) 
ON Target.[Email] = Source.[Email] AND Target.[Code_ID] = Source.[Code_ID] AND
   Target.[Entrepreneur_Email] = Source.[Entrepreneur_Email] AND Target.[Category_ID] = Source.[Category_ID]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Email], [Code_ID], [Entrepreneur_Email], [Category_ID]) 
VALUES ([Email], [Code_ID], [Entrepreneur_Email], [Category_ID]);
